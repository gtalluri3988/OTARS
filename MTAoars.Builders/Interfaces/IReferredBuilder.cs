using MTAoars.ViewModels.Administrative;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTAoars.Builders.Interfaces
{
    public interface IReferredBuilder : IBaseBuilder
    {
        ReferredSearchViewModel SearchReferredMember(string IcNumber);

        ReferredSearchViewModel SearchReferredMemberDetail(int id);

        string GetCategoryDescription(string IcNumber);

        string GetReferredMemberDateCreated(string IcNumber);

    }
}
