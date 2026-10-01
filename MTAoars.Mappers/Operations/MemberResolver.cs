using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using MTAoars.DomainModels;
using MTAoars.ViewModels.Operations;
using System.Data.Objects.DataClasses;
using MTAoars.Utilities.Mvc;

namespace MTAoars.Mappers.Operations {
    class MemberResolver : ValueResolver<RegistrationIndexViewModel, CorporateNomineeViewModel>
    {
        protected override CorporateNomineeViewModel ResolveCore(RegistrationIndexViewModel source) {
            CorporateNomineeViewModel nominee = null;
            //source.
            //if (source.AgencyMembers != null) {
            //    if (source.AgencyMembers.Count > 0) {
            //        var member = source.AgencyMembers.First(am=>am..Member;
            //        nominee = Mapper.Map<CorporateNomineeViewModel>(member);
            //        nominee.Qualification = new QualificationViewModel();

            //    }
            //}
            return nominee;
        }

    }// class
}// namespace
