using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.DomainModels;
using System.Data.Objects.DataClasses;
using MTAoars.ViewModels.Operations;
using MTAoars.Utilities.Extensions;
using AutoMapper;
using MTAoars.Repositories.Interfaces;
using MTAoars.Utilities.Constants;
using MTAoars.ViewModels.Shared;
using MTAoars.Utilities.Interfaces;
using MTAoars.Utilities.Mvc;



namespace MTAoars.Mappers.Operations {

    class GuarantorDisplayResolver : ValueResolver<Agency, GuarantorDisplayViewModel> {
        IMemberRepository memberRepository;
        IScopeDataProvider dataProvider;

        public GuarantorDisplayResolver(IMemberRepository memberRepository, IScopeDataProvider dataProvider) {
            this.memberRepository = memberRepository;
            this.dataProvider = dataProvider;
        }

        protected override GuarantorDisplayViewModel ResolveCore(Agency source) {
            var companyId = dataProvider.Get<Identity>(GlobalConstants.CurrentIdentity).CompanyID;
            var ap = source.AgencyPrincipals.FirstOrDefault(p=>p.CompanyID == companyId);
            if(ap == null) return null;
            var guarantor = ap.AgencyPrincipalGuarantors.FirstOrDefault();
            if(guarantor == null) return null;
            return Mapper.Map<GuarantorDisplayViewModel>(guarantor);
        }

    }

}
