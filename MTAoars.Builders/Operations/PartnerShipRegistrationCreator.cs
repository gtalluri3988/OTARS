using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Operations;
using MTAoars.Repositories.Interfaces;
using MTAoars.Builders.Interfaces;
using Microsoft.Practices.Unity;
using MTAoars.Validators.Operations.Fluents;

namespace MTAoars.Builders.Operations
{
    public class PartnerShipRegistrationCreator: RegistrationCreator, IRegsitrationCreator
    {

        IUnityContainer container;
        public PartnerShipRegistrationCreator(ILookupRepository lookupRepository, IUnityContainer container)
            : base(lookupRepository,container)
        {
            this.container = container;
        }


       
        public override void Process(RegistrationViewModel model)
        {
            base.Process(model);
        }

        public RegistrationViewModel Create(List<string> parameters)
        {
            base.Parameters = parameters;
            var model = new PartnershipRegistrationViewModel();
            Process(model);            
            return model;
        }
     
    }
}

