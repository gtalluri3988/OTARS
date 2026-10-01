using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using MTAoars.DomainModels;
using MTAoars.ViewModels.Shared;
using MTAoars.Utilities.Mvc;

namespace MTAoars.Mappers.Shared {
    public class LookupMapper : IMapper {

        public void Map() {
            Mapper.CreateMap<ILookupEntity, LookupItem>();
            Mapper.CreateMap<Company, LookupItem>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Name));
            Mapper.CreateMap<Activity, LookupItem>();
        }

    }
}
