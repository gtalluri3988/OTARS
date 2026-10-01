using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.DomainModels;
using MTAoars.Repositories.Administrative;
using MTAoars.ViewModels.Administrative;

namespace MTAoars.Repositories.Interfaces
{
    public interface IReferredMemberRepository : IRepository<ReferredMember>
    {

        List<ReferredMember> GetMembers(string IcNumber);

        ReferredMember GetMember(int ID);

        List<LookupReferredReason> GetLookupReasons(int CategoryID);

        string LookupReferredReason(int ID);

        string LookupReferredCategory(int ID);

        void UpdateReferred(ReferredSearchViewModel model, out string message);

        ReferredDetail ReferredDetail(ReferredMember ReferredMember);
        List<LookupReferredActionTaken> GetLookupReferredActionTaken(int ActionId);
        string LookupReferredActionTaken(int ID);

        string GetCategoryDescription(string IcNumber);

        string GetReferredMemberDateCreated(string IcNumber);
    }
}
