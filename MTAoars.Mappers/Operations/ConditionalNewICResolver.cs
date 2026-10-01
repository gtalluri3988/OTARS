using MTAoars.DomainModels;
using AutoMapper;
using MTAoars.Repositories.Interfaces;
using MTAoars.Utilities.Constants;
using MTAoars.ViewModels.Interfaces;


namespace MTAoars.Mappers.Operations {

    class ConditionalNewICResolver : ValueResolver<IMemberViewModel, string> {
        ILookupRepository lookupRepository;

        public ConditionalNewICResolver(ILookupRepository lookupRepository) {
            this.lookupRepository = lookupRepository;
            
        }

        protected override string ResolveCore(IMemberViewModel source) {
            if (source.ICType.Code == LookupConstants.ICTypes.NewIc)
                return source.ICNumber.Trim();
            return null;
        }

    }

}
