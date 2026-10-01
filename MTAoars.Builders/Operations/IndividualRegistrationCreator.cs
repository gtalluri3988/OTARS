using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.Builders.Interfaces;
using MTAoars.ViewModels.Operations;
using MTAoars.Repositories.Interfaces;
using MTAoars.Validators.Operations.Fluents;
using Microsoft.Practices.Unity;
namespace MTAoars.Builders.Operations
{
    public class IndividualRegistrationCreator : RegistrationCreator, IRegsitrationCreator
    {
        IUnityContainer container;

        public IndividualRegistrationCreator(ILookupRepository lookupRepository, IUnityContainer container)
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
            var model = new IndividualRegistrationViewModel();       
            
            
            Process(model);
           
            return model;
        }

       
    }
}
