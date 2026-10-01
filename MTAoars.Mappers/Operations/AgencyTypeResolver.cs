using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using MTAoars.ViewModels.Operations;
using MTAoars.Repositories.Interfaces;
using MTAoars.DomainModels;
using MTAoars.Utilities.Mvc;
using MTAoars.Utilities.Interfaces;
using MTAoars.Utilities.Constants;

namespace MTAoars.Mappers.Operations {

   class AgencyTypeResolver : ValueResolver<Agency, LookupItem> {

        ILookupRepository lookupRepository;
        IScopeDataProvider dataProvider;
        public AgencyTypeResolver(ILookupRepository lookupRepository, IScopeDataProvider dataProvider) {
            this.lookupRepository = lookupRepository;
            this.dataProvider = dataProvider;
        }

        protected override LookupItem ResolveCore(Agency source) {
            var companyId = dataProvider.Get<Identity>(GlobalConstants.CurrentIdentity).CompanyID;
            var ap = source.AgencyPrincipals.FirstOrDefault(p => p.CompanyID == companyId);
            if (ap == null) return null;
            return Mapper.Map<LookupItem>(ap.LookupAgencyType);

        }

    }// class

}// namespace
