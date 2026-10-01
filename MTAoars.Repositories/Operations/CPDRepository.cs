using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.Repositories.Interfaces;
using MTAoars.Repositories.Shared;
using MTAoars.DomainModels;
using MTAoars.Utilities.Config;
using MTAoars.Utilities.Constants;
using MTAoars.Utilities.Interfaces;
using MTAoars.Utilities.Mvc;

namespace MTAoars.Repositories.Operations {

    public class CPDRepository : GenericRepository<CPDDetail>, ICPDRepository {
        ConfigManager config;
        IScopeDataProvider dataProvider;
        public CPDRepository(EntityContext context, ConfigManager config, IScopeDataProvider dataProvider)
            : base(context) {
                this.config = config;
                this.dataProvider = dataProvider;
        }

        public bool IsProcessed(int year) {
            return Context.CPDDetails.Count(p => p.Year == year) > 0;
        }

        public void Process(int year) {
            var identity = dataProvider.Get<Identity>(GlobalConstants.CurrentIdentity);
            Context.ProcessCPD(year, identity.UserID);
        }

        public IEnumerable<CPDDetail> Get(int year, string statusCode) {
            return Context.CPDDetails.Where(p => p.Year == year && p.LookupCPDStatus.Code == statusCode).ToList();
        }

    }// class

}// namespace
