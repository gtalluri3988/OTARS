using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Shared;
using MTAoars.Utilities.Constants;
using MTAoars.ViewModels.Interfaces;
using Microsoft.Practices.Unity;

namespace MTAoars.ViewModels.Operations
{

    public class AdministrativeAgentSoleProprietorshipViewModel : AdministrativeAgentViewModel, IExistableAgencyBanker, IExistableAgency
    {
        [Dependency]
        public AgencyBankerViewModel AgencyBanker { get; set; }

    }// class

}// namespace
