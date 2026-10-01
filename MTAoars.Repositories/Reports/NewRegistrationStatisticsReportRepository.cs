using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.Repositories.Interfaces;
using System.Data;
using System.Data.SqlClient;
using System.Data.EntityClient;
using MTAoars.Utilities.Config;
using MTAoars.Utilities.Constants;
using MTAoars.DomainModels;
using MTAoars.Utilities.Interfaces;
using MTAoars.Utilities.Mvc;
using System.Threading.Tasks;
using MTAoars.Utilities.IoC;
using Microsoft.Practices.Unity;

namespace MTAoars.Repositories.Reports {
    
    public class NewRegistrationStatisticsReportRepository : IReportRepository{

        EntityContext context;
        ILookupRepository lookupRepository;
        IScopeDataProvider dataProvider;

        public NewRegistrationStatisticsReportRepository(EntityContext context, ILookupRepository lookupRepository, IScopeDataProvider dataProvider) {
            this.context = context;
            this.lookupRepository = lookupRepository;
            this.dataProvider = dataProvider;
        }

        public Dictionary<string, IEnumerable<dynamic>> GetData(Dictionary<string, string> parameters) {
            long? companyId = null;
            var identity = dataProvider.Get<Identity>(GlobalConstants.CurrentIdentity);
            if (!identity.IsISMOrMTA) companyId = identity.CompanyID;
            var year = int.Parse(parameters["Year"]);
            var month = int.Parse(parameters["Month"]);
            var intermediaryType = parameters["IntermediaryTypeCode"];
            var category = parameters["RegistrationCategory"];
            var intermediaryTypeId = lookupRepository.Get<LookupIntermediaryType>(intermediaryType).ID;
            var output = new Dictionary<string, IEnumerable<dynamic>>();
            var list = new List<Task>();
            var tasks = new Task[] {
                 Task.Factory.StartNew(() => output.Add("BancaOnePrincipal",
                    GetNewContext().GetNewRegistrationStatisticsReport(intermediaryTypeId, true, year, month, 0, 1, category, companyId))),
                Task.Factory.StartNew(() => output.Add("BancaMultiPrincipal",
                    GetNewContext().GetNewRegistrationStatisticsReport(intermediaryTypeId, true, year, month, 2, 5, category, companyId))),
                Task.Factory.StartNew(() => output.Add("NonBancaOnePrincipal",
                    GetNewContext().GetNewRegistrationStatisticsReport(intermediaryTypeId, false, year, month, 0, 1, category, companyId))),
                Task.Factory.StartNew(() => output.Add("NonBancaMultiPrincipal",
                    GetNewContext().GetNewRegistrationStatisticsReport(intermediaryTypeId, false, year, month, 2, 5, category, companyId)))
               
            };

            Task.WaitAll(tasks);
            return output;
        }


        public Dictionary<string, string> GetParameters(Dictionary<string, string> parameters) {
            var output = new Dictionary<string, string>();
            output.Add("Year", parameters["Year"]);
            output.Add("Month", parameters["Month"]);
            return output;
        }

        EntityContext GetNewContext() {
            return ObjectContainer.Container.Resolve<EntityContext>();
        }

    }// class

}// namespace
