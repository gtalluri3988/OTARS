using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTAoars.DomainModels;
using System.Data.Objects.DataClasses;
using MTAoars.ViewModels.Operations;
using MTAoars.Utilities.Extensions;
using AutoMapper;
using MTAoars.Repositories.Interfaces;
using MTAoars.Utilities.Constants;


namespace MTAoars.Mappers.Operations {

    class AgencyPrincipalViewModelResolver : ValueResolver<Agency, List<AgencyPrincipalDisplayViewModel>> {
       
        public AgencyPrincipalViewModelResolver() {
           
        }

        protected override List<AgencyPrincipalDisplayViewModel> ResolveCore(Agency source) {
            var output = new List<AgencyPrincipalDisplayViewModel>();
            foreach (var ap in source.AgencyPrincipals) {
                output.Add(Mapper.Map<AgencyPrincipalDisplayViewModel>(ap));
            }
            foreach (var aph in source.AgencyPrincipalHistories) {
                output.Add(Mapper.Map<AgencyPrincipalDisplayViewModel>(aph));
            }
            return output;
        }

        
    }

}
