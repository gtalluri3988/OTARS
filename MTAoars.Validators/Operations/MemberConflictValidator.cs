using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Shared;
using MTAoars.Repositories.Interfaces;
using MTAoars.DomainModels;
using MTAoars.ViewModels.Interfaces;
using MTAoars.Utilities.Interfaces;
using MTAoars.Utilities.Constants;

namespace MTAoars.Validators.Operations {
    public class MemberConflictValidator : IValidator<IMemberViewModel> {
        IMemberRepository memberRepository;

        public MemberConflictValidator(IMemberRepository memberRepository) {
            this.memberRepository = memberRepository;
        }

        public IEnumerable<ValidationMessage> Validate(IMemberViewModel item) {
            var result = memberRepository.IsMemberExistsInConflict(item.ICNumber);
            if (result == true) {
                yield return new ValidationMessage("", "The member is already in conflict and cannot be processed now.");
            }
        }

    }// class
}// namespace
