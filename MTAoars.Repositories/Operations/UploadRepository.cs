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

    public class UploadRepository : GenericRepository<UploadHistory>, IUploadRepository {
        ConfigManager config;
        public UploadRepository(EntityContext context, ConfigManager config)
            : base(context) {
                this.config = config;
        }

        public string GetAgencyNumber(long agencyId) {
            return Context.AgencyPrincipals.Where(p => p.AgencyID == agencyId).OrderByDescending(p => p.CreatedDate)
                .Select(p => p.AgencyNumber).FirstOrDefault();
        }

    }// class

}// namespace
