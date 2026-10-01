using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using MTAoars.DomainModels;
using MTAoars.ViewModels.Operations;
using MTAoars.ViewModels.Enquiries;

namespace MTAoars.Mappers.Operations {

    public class EnquiryMapper : IMapper {

        public void Map() {
            Mapper.CreateMap<SearchViewModel, SearchResultViewModel>()
                .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company.Description));

            Mapper.CreateMap<SearchViewModel, EnquiryLog>()
                .ForMember(dest => dest.CompanyID, opt => opt.MapFrom(src => src.Company.ID))
                .ForMember(dest => dest.IPAddress, opt => opt.MapFrom(src => src.Company.ID))
                .ForMember(dest => dest.AgencyNumber, opt => opt.MapFrom(src => src.RegistrationNumber));
           
                  
        }       

    }// class

}// namespace
