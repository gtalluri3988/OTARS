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

namespace MTAoars.ViewModels.Operations
{

    public class AdministrativeAgentCorporateViewModel : AdministrativeAgentViewModel, IExistableAgencyBanker, IExistableBoardMembers, IExistableAgency, IExistableAddressAgencyBoardMembers
    {
        public AdministrativeAgentCorporateViewModel()
        {
            Directors = new List<DirectorViewModel>();
            Shareholders = new List<ShareholderViewModel>();
            AdditionalCorporateNominees = new List<AdditionalCorporateNomineeViewModel>();
        }

        [Binder(typeof(JsonModelBinder))]
        public List<DirectorViewModel> Directors { get; set; }


        [Binder(typeof(JsonModelBinder))]
        public List<ShareholderViewModel> Shareholders { get; set; }

        public List<AdditionalCorporateNomineeViewModel> AdditionalCorporateNominees { get; set; }

        [Dependency]
        public AgencyBankerViewModel AgencyBanker { get; set; }

    }// class
}
