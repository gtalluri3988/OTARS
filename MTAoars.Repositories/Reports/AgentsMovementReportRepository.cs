using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MTAoars.DomainModels;
using MTAoars.Repositories.Interfaces;
using MTAoars.Utilities.Constants;
using MTAoars.Utilities.Interfaces;
using MTAoars.Utilities.Mvc;
using MTAoars.ViewModels.Reports;

namespace MTAoars.Repositories.Reports
{
    public class AgentsMovementReportRepository : IReportRepository
    {
        readonly EntityContext context;
        readonly IScopeDataProvider dataProvider;

        public AgentsMovementReportRepository(EntityContext context, IScopeDataProvider dataProvider)
        {
            this.context = context;
            this.dataProvider = dataProvider;
        }

        public Dictionary<string, IEnumerable<dynamic>> GetData(Dictionary<string, string> parameters)
        {
            var identity = dataProvider.Get<Identity>(GlobalConstants.CurrentIdentity);
            if (!identity.IsAdmin)
                return EmptyResult();

            var fromMonth = int.Parse(parameters["FromMonth"]);
            var fromYear = int.Parse(parameters["FromYear"]);
            var toMonth = int.Parse(parameters["ToMonth"]);
            var toYear = int.Parse(parameters["ToYear"]);

            if (!IsValidMonthRange(fromYear, fromMonth, toYear, toMonth))
                return EmptyResult();

            var fromDate = new DateTime(fromYear, fromMonth, 1);
            var toDateEnd = new DateTime(toYear, toMonth, DateTime.DaysInMonth(toYear, toMonth)).Date.AddDays(1).AddTicks(-1);

            context.CommandTimeout = 10 * 60;

            var principals = context.AgencyPrincipals
                .Include("Agency")
                .Include("Agency.AgencyMembers")
                .Include("Agency.AgencyMembers.Member")
                .Include("Agency.AgencyMembers.LookupDesignation")
                .Include("Company")
                .Include("LookupAgencyType")
                .Include("LookupIntermediaryType")
                .Include("Member")
                .Where(ap => (ap.CreatedDate ?? ap.ValidFrom) >= fromDate && (ap.CreatedDate ?? ap.ValidFrom) <= toDateEnd)
                .ToList();

            if (principals.Count == 0)
            {
                var empty = new Dictionary<string, IEnumerable<dynamic>>();
                empty.Add(LookupConstants.Reports.AgentsMovementReport, new List<AgentsMovementReportDetail>());
                return empty;
            }

            var agencyIds = principals.Select(p => p.AgencyID).Distinct().ToList();
            var intTypeIds = principals.Select(p => p.IntermediaryTypeID).Distinct().ToList();

            var histories = context.AgencyPrincipalHistories
                .Include("Company")
                .Where(h => agencyIds.Contains(h.AgencyID) && intTypeIds.Contains(h.IntermediaryTypeID))
                .ToList();

            var userIds = principals.Where(p => p.CreatedBy.HasValue).Select(p => p.CreatedBy.Value).Distinct().ToList();
            var users = context.Users.Where(u => userIds.Contains(u.ID)).ToDictionary(u => u.ID, u => u.UserName);

            var rows = new List<AgentsMovementReportDetail>();
            foreach (var ap in principals.OrderBy(p => p.Agency != null ? p.Agency.Name : "").ThenBy(p => p.Company != null ? p.Company.Name : ""))
            {
                var prev = histories
                    .Where(h => h.AgencyID == ap.AgencyID && h.IntermediaryTypeID == ap.IntermediaryTypeID && h.ValidFrom < ap.ValidFrom)
                    .OrderByDescending(h => h.ValidFrom)
                    .FirstOrDefault();

                string nomineePrincipal = "";
                if (ap.Member != null)
                    nomineePrincipal = ap.Member.Name;
                else if (ap.Agency != null)
                    nomineePrincipal = ap.Agency.Name;

                var corporateNominee = GetCorporateNomineeMember(ap);

                string corporateNomineeNric = "";
                if (corporateNominee != null)
                    corporateNomineeNric = FirstNonEmpty(corporateNominee.NewICNumber, corporateNominee.OldICNumber, corporateNominee.PassportNumber);

                string createdByName = "";
                if (ap.CreatedBy.HasValue)
                {
                    long uid = ap.CreatedBy.Value;
                    if (users.ContainsKey(uid))
                        createdByName = users[uid];
                }

                string prevName = prev != null && prev.Company != null ? prev.Company.Name : "";
                DateTime? term = prev != null ? prev.TerminationDate ?? prev.ValidTo : null;

                rows.Add(new AgentsMovementReportDetail
                {
                    AgentAgency = ap.Agency != null ? ap.Agency.Name : "",
                    RegistrationType = ap.LookupAgencyType != null ? ap.LookupAgencyType.Description : "",
                    IntermediaryType = ap.LookupIntermediaryType != null ? ap.LookupIntermediaryType.Description : "",
                    NomineePrincipal = nomineePrincipal,
                    CorporateNomineeNricNumber = corporateNomineeNric,
                    TakafulOperator = ap.Company != null ? ap.Company.Name : "",
                    DateAppointed = ap.DateAppointed,
                    DateCreated = ap.CreatedDate,
                    CreatedBy = createdByName,
                    ValidFrom = ap.ValidFrom,
                    ValidTo = ap.ValidTo,
                    PreviousTakafulOperator = prevName,
                    DateTerminated = term
                });
            }

            for (var i = 0; i < rows.Count; i++)
                rows[i].SerialNo = i + 1;

            var output = new Dictionary<string, IEnumerable<dynamic>>();
            output.Add(LookupConstants.Reports.AgentsMovementReport, rows);
            return output;
        }

        static Member GetCorporateNomineeMember(AgencyPrincipal ap)
        {
            if (ap.Member != null)
                return ap.Member;
            if (ap.Agency?.AgencyMembers == null)
                return null;
            foreach (var am in ap.Agency.AgencyMembers)
            {
                if (am.Member != null && am.LookupDesignation != null
                    && am.LookupDesignation.Code == LookupConstants.Designation.CorporateNominee)
                    return am.Member;
            }
            return null;
        }

        static string FirstNonEmpty(params string[] values)
        {
            if (values == null)
                return "";
            foreach (var v in values)
            {
                if (!string.IsNullOrWhiteSpace(v))
                    return v.Trim();
            }
            return "";
        }

        static bool IsValidMonthRange(int fromYear, int fromMonth, int toYear, int toMonth)
        {
            if (fromMonth < 1 || fromMonth > 12 || toMonth < 1 || toMonth > 12)
                return false;
            var span = (toYear - fromYear) * 12 + (toMonth - fromMonth) + 1;
            return span >= 1 && span <= 12;
        }

        static Dictionary<string, IEnumerable<dynamic>> EmptyResult()
        {
            var empty = new Dictionary<string, IEnumerable<dynamic>>();
            empty.Add(LookupConstants.Reports.AgentsMovementReport, new List<AgentsMovementReportDetail>());
            return empty;
        }

        public Dictionary<string, string> GetParameters(Dictionary<string, string> parameters)
        {
            var fromMonth = int.Parse(parameters["FromMonth"]);
            var fromYear = int.Parse(parameters["FromYear"]);
            var toMonth = int.Parse(parameters["ToMonth"]);
            var toYear = int.Parse(parameters["ToYear"]);

            var fromLabel = new DateTime(fromYear, fromMonth, 1).ToString("MMMM yyyy");
            var toLabel = new DateTime(toYear, toMonth, 1).ToString("MMMM yyyy");

            var output = new Dictionary<string, string>();
            output.Add("FromMonth", parameters["FromMonth"]);
            output.Add("FromYear", parameters["FromYear"]);
            output.Add("ToMonth", parameters["ToMonth"]);
            output.Add("ToYear", parameters["ToYear"]);
            output.Add("FromLabel", fromLabel);
            output.Add("ToLabel", toLabel);
            return output;
        }
    }
}
