using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using MTAoars.DomainModels;
using MTAoars.ViewModels.Shared;
using MTAoars.Utilities.Mvc;

namespace MTAoars.Mappers.Shared {
    public class GlobalMapper : IMapper {

        public void Map() {
            Mapper.CreateMap<Address, AddressViewModel>()
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => Mapper.Map<LookupItem>(src.LookupState)));
            Mapper.CreateMap<AddressViewModel, Address>()
                .ForMember(dest => dest.StateID, opt => opt.MapFrom(src => GetLookupID(src.State)));
            
        }

        long? GetLookupID(LookupItem item) {
            if (item == null) return null;
            return item.ID;
        }
    }// class
}// namespace
