﻿using AutoMapper;
using Xphyrus.AssesmentAPI.Models;
using Xphyrus.AssesmentAPI.Models.Dto;


namespace Xphyrus.AssesmentAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingCOnfig = new MapperConfiguration(config =>
            {
               config.CreateMap<AssesmentDto, Assesment>().ReverseMap();
                config.CreateMap<CodingDto, Coding>().ReverseMap();
                config.CreateMap<EvliationCaseDto, EvliationCase>().ReverseMap();
                config.CreateMap<MasterCodeDto, MasterCode>().ReverseMap();
                config.CreateMap<COnstraint, COnstraintDto>().ReverseMap();
                config.CreateMap<Example, ExampleDto>().ReverseMap();
                config.CreateMap<AssesmentDto, Assesment>().ReverseMap();
            });
                return mappingCOnfig;
        }
    }
}
