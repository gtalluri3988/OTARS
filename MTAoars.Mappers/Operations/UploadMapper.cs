using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using MTAoars.DomainModels;
using MTAoars.ViewModels.Operations;
using MTAoars.ViewModels.Maintenance;
using MTAoars.ViewModels.Notifications;

namespace MTAoars.Mappers.Operations {

    public class UploadMapper : IMapper {

        public void Map() {
            Mapper.CreateMap<UploadHistory, ExcelUploadVariableSource>()
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.UploadFileName));
            MapIbfim();
                  
        }

        void MapIbfim() {
            Mapper.CreateMap<IbfimExcelViewModel, IbfimResult>()
                .ForMember(dest => dest.IsActive, opt => opt.UseValue(true))
                .ForMember(dest => dest.ICNumber, opt => opt.MapFrom(src => src.ICNO))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.StudentName))
                .ForMember(dest => dest.CompanyCode, opt => opt.MapFrom(src => src.TakafulOperatorCode));
        }

        

    }// class

}// namespace
