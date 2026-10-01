using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using MTAoars.ViewModels.Operations;
using MTAoars.Repositories.Interfaces;
using MTAoars.DomainModels;
using MTAoars.Utilities.Constants;

namespace MTAoars.Mappers.Operations {

    class TerminationScheduleStatusResolver : ValueResolver<TerminationSearchResponseViewModel, long> {

        ILookupRepository lookupRepository;

        public TerminationScheduleStatusResolver(ILookupRepository lookupRepository) {
            this.lookupRepository = lookupRepository;
        }

        protected override long ResolveCore(TerminationSearchResponseViewModel source) {
            return lookupRepository.Get<LookupTerminationStatus>(LookupConstants.TerminationStatus.Scheduled).ID;
        }

    }// class

}// namespace
