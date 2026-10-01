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



namespace MTAoars.Mappers.Operations {

    class AdditionalCorporateNomineeDisplayResolver : ValueResolver<Agency, List<MemberDisplayViewModel>> {
        IMemberRepository memberRepository;

        public AdditionalCorporateNomineeDisplayResolver(IMemberRepository memberRepository) {
            this.memberRepository = memberRepository;
        }

        protected override List<MemberDisplayViewModel> ResolveCore(Agency source) {
            var result = new List<MemberDisplayViewModel>();
            var members = source.AgencyMembers.Where(desig => desig.LookupDesignation.Code == LookupConstants.Designation.AdditionalCorporateNominee)
                .Select(p=>p.Member);
            foreach (var member in members) {
                result.Add(Mapper.Map<MemberDisplayViewModel>(member));
            }
            return result;
        }

    }

}
