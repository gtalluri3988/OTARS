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
using MTAoars.ViewModels.Shared;
using MTAoars.ViewModels.Interfaces;



namespace MTAoars.Mappers.Operations {

    class AgencyPrincipalStatusHistoryMappingAction : IMappingAction<AgencyPrincipal, AgencyPrincipalHistory> {

        public void Process(AgencyPrincipal source, AgencyPrincipalHistory destination) {
            foreach (var item in source.AgencyPrincipalStatus) {
                destination.AgencyPrincipalStatusHistories.Add(Mapper.Map<AgencyPrincipalStatusHistory>(item));
            }
        }

    }// class
}// namespace
