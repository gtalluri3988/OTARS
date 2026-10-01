using MTAoars.DomainModels;
using AutoMapper;
using MTAoars.Repositories.Interfaces;
using MTAoars.Utilities.Constants;
using MTAoars.ViewModels.Interfaces;


namespace MTAoars.Mappers.Operations {

    class ConditionalPassportNumberResolver : ValueResolver<IMemberViewModel, string> {
        ILookupRepository lookupRepository;

        public ConditionalPassportNumberResolver(ILookupRepository lookupRepository) {
            this.lookupRepository = lookupRepository;
            
        }

        protected override string ResolveCore(IMemberViewModel source) {
            if (source.ICType.Code == LookupConstants.ICTypes.PoliceArmyPassport)
                return source.ICNumber;
            return null;
        }

    }

}
