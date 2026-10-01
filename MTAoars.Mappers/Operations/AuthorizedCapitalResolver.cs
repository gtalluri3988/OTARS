using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using MTAoars.DomainModels;
using MTAoars.Utilities.Interfaces;
using MTAoars.Utilities.Mvc;
using MTAoars.Utilities.Constants;

namespace MTAoars.Mappers.Operations {
    class AuthorizedCapitalResolver :ValueResolver<Agency, bool>
    {
        
        IScopeDataProvider dataProvider;
        public AuthorizedCapitalResolver(IScopeDataProvider dataProvider)
        {           
            this.dataProvider = dataProvider;
        }
        protected override bool ResolveCore(Agency source)
        {
           
            var companyId = dataProvider.Get<Identity>(GlobalConstants.CurrentIdentity).CompanyID;
            var ap = source.AgencyPrincipals.FirstOrDefault(p => p.CompanyID == companyId);
            if (ap == null) return false;
            var code = ap.LookupAgencyType.Code;
            if (code == LookupConstants.AgencyType.PrivateLimitedCompany || code == LookupConstants.AgencyType.PublicLimitedCompany
                || code == LookupConstants.AgencyType.Cooperative || code == LookupConstants.AgencyType.GovernmentAgency) {
                    return true;                 
            }
            return false;  
        }
    }
}
