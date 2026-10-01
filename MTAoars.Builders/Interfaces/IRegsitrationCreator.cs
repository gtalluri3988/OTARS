using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.ViewModels.Operations;

namespace MTAoars.Builders.Interfaces
{
    public interface IRegsitrationCreator
    {
         void Process(RegistrationViewModel model);
         RegistrationViewModel Create(List<string> parameters);
        
         Dictionary<string, string> ErrorHandler{get;set;}
    }
}
