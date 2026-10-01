using System;
using MTAoars.DomainModels;
using MTAoars.ViewModels.Operations;
using AutoMapper;
using MTAoars.Repositories.Interfaces;
using MTAoars.Utilities.Constants;


namespace MTAoars.Mappers.Operations {

    class ConditionalNewICToGenderResolver : ValueResolver<RegistrationIndexViewModel, long?> {
        ILookupRepository lookupRepository;

        public ConditionalNewICToGenderResolver(ILookupRepository lookupRepository) {
            this.lookupRepository = lookupRepository;
            
        }

        protected override long? ResolveCore(RegistrationIndexViewModel source) {
            if (source.ICType.Code != LookupConstants.ICTypes.NewIc) return null;
            if (String.IsNullOrEmpty(source.ICNumber)) return null;
            if (source.ICNumber.Length < 9) return null;
            int result;
            if (!int.TryParse(source.ICNumber.Substring(source.ICNumber.Length - 1), out result)) return null;
            if (result % 2 == 0) return lookupRepository.Get<LookupGender>(LookupConstants.Gender.Female).ID;
            return lookupRepository.Get<LookupGender>(LookupConstants.Gender.Male).ID;
        }

    }

}
