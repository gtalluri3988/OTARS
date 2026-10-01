using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.Repositories.Interfaces;
using MTAoars.Repositories.Shared;
using MTAoars.DomainModels;
using MTAoars.Utilities.Config;
using MTAoars.Utilities.Constants;

namespace MTAoars.Repositories.Operations {

    public class ConflictRepository : GenericRepository<AgencyPrincipalConflict>, IConflictRepository {
        
        public ConflictRepository(EntityContext context)
            : base(context) {
                
        }


        public IEnumerable<AgencyPrincipalConflict> SelectOpenConflicts(int days) {
            return SelectConflicts(days, LookupConstants.ConflictStatus.Open);
        }

        public IEnumerable<AgencyPrincipalConflict> SelectConflicts(int days, String statusCode) {
            return Context.AgencyPrincipalConflicts.Where(p => p.LookupConflictStatus.Code == statusCode)
                .ToList().Where(p => p.CreatedDate < DateTime.Now.AddDays(days * -1));

        }

        public AgencyPrincipalConflict GetOpenConflict(long agencyId, long companyId) {
            return Context.AgencyPrincipalConflicts.FirstOrDefault(p=>p.AgencyID == agencyId
                && p.SourceCompanyID == companyId
                && p.LookupConflictStatus.Code == LookupConstants.ConflictStatus.Open);
        }

        public AgencyPrincipalConflict GetNotClosedConflict(long agencyId, long companyId) {
            return Context.AgencyPrincipalConflicts.FirstOrDefault(p => p.AgencyID == agencyId
               && p.SourceCompanyID == companyId
               && p.LookupConflictStatus.Code != LookupConstants.ConflictStatus.Closed);
        }

        public AgencyPrincipalConflict GetNotClosedAndNotRejectedConflict(long agencyId, long companyId) {
            return Context.AgencyPrincipalConflicts.FirstOrDefault(p => p.AgencyID == agencyId
               && p.SourceCompanyID == companyId
               && p.LookupConflictStatus.Code != LookupConstants.ConflictStatus.Closed
               && p.LookupConflictStatus.Code != LookupConstants.ConflictStatus.Rejected);
        }

        public AgencyPrincipal GetSourceCompanyPrincipal(long id) {
            var conflict = Context.AgencyPrincipalConflicts.FirstOrDefault(p => p.ID == id);
            if (conflict == null) return null;
            return conflict.Agency.AgencyPrincipals
                .First(p => p.IntermediaryTypeID == conflict.IntermediaryTypeID
                    && p.CompanyID == conflict.SourceCompanyID);
                
        }

        public bool IsAgencyPrincipalExists(long agencyId, long companyId, long intermediaryTypeId) {
            return Context.AgencyPrincipals.Count(p => p.AgencyID == agencyId
                && p.CompanyID == companyId
                && p.IntermediaryTypeID == intermediaryTypeId) > 0;
        }
    }// class

}// namespace
