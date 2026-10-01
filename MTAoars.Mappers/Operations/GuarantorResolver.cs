using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using MTAoars.DomainModels;
using MTAoars.ViewModels.Operations;
using MTAoars.Utilities.Interfaces;
using MTAoars.Utilities.Constants;
using MTAoars.Repositories.Interfaces;
using MTAoars.ViewModels.Shared;
using MTAoars.Utilities.Mvc;

namespace MTAoars.Mappers.Operations
{
    class GuarantorResolver : ValueResolver<Agency, GuarantorViewModel>
    {
        IMemberRepository memberRepository;
        IScopeDataProvider dataProvider;
        public GuarantorResolver(IMemberRepository memberRepository, IScopeDataProvider dataProvider)
        {
            this.memberRepository = memberRepository;
            this.dataProvider = dataProvider;
        }
        protected override GuarantorViewModel ResolveCore(Agency source)
        {
            GuarantorViewModel guarantorModel = new GuarantorViewModel();
            var companyId = dataProvider.Get<Identity>(GlobalConstants.CurrentIdentity).CompanyID;
            var ap = source.AgencyPrincipals.FirstOrDefault(p => p.CompanyID == companyId);
            if (ap == null) return null;
            var guarantor = ap.AgencyPrincipalGuarantors.FirstOrDefault();
            if (guarantor == null) return null;
            guarantorModel.GuarantorType =  Mapper.Map<LookupItem>(guarantor.LookupGuarantorType);
            Mapper.Map(guarantor, guarantorModel);
            return guarantorModel;
        }
    }
}
