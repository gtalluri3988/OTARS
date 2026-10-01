using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Shared;
using MTAoars.Utilities.Constants;
using Microsoft.Practices.Unity;
using MTAoars.Utilities.Attributes;
using MTAoars.Utilities.Mvc;
using MTAoars.ViewModels.Interfaces;

namespace MTAoars.ViewModels.Operations {

    public class PartnershipRegistrationViewModel : RegistrationViewModel, IExistableAgencyBanker, IExistableAgency {

        public PartnershipRegistrationViewModel() {
            this.Partners = new MemberList<PartnerViewModel>(this);
        }

        [Binder(typeof(JsonModelBinder))]
        public List<PartnerViewModel> Partners { get; set; }

        [Dependency]
        public AgencyBankerViewModel AgencyBanker { get; set; }

        
              
    }// class

}// namespace
