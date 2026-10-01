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

namespace MTAoars.Validators.Operations
{
    public class ReferredMemberValidator : IValidator<IMemberViewModel>
    {
        IMemberRepository memberRepository;

        public ReferredMemberValidator(IMemberRepository memberRepository)
        {
            this.memberRepository = memberRepository;
        }

        public IEnumerable<ValidationMessage> Validate(IMemberViewModel item)
        {
            //var result = memberRepository.IsMemeberReasonNotAllowedForRegistration(item.ICNumber);
            var result = memberRepository.IsMemeberReasonNotAllowedForRegistrationByIntermediary(item.ICNumber, item.IsFamily, item.IsGeneral);
            if (result == true)
            {
                var messageTemplate = "This agent appears in the referred listing under ({0}) on {1}";
                var referredMembers = memberRepository.GetReferredMembers(item.ICNumber);
                foreach (var refMember in referredMembers)
                {
                    if (refMember == null) continue;
                    var msg = string.Format(messageTemplate, refMember.LookupReferredCategory.Description,
                        refMember.CreatedDate.HasValue ? Convert.ToDateTime(refMember.CreatedDate).ToString("dd/MM/yyyy") : "-");
                    yield return new ValidationMessage("", msg);
                }
            }

            //[20210125] - To allow TO to register referred member as “General” if referred member only exists in “Family” (vice-versa)
            //Comment out the checking below ...
            //result = memberRepository.IsMemberReferredAndNotAllowedForRegistration(item.ICNumber);

            yield break;
        }

    }// class
}// namespace
