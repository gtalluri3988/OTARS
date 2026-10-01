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

    class SpouseDisplayResolver : ValueResolver<Agency, MemberDisplayViewModel> {
        IMemberRepository memberRepository;

        public SpouseDisplayResolver(IMemberRepository memberRepository) {
            this.memberRepository = memberRepository;
        }

        protected override MemberDisplayViewModel ResolveCore(Agency source) {
            var member = memberRepository.GetCorporateNominee(source.ID);
            if (member.Spouses.Count == 0) return null;
            return Mapper.Map<MemberDisplayViewModel>(member.Spouses.First());
        }

    }

}
