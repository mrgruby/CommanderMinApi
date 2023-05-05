using AutoMapper;
using CommanderMinApi.Application.RequestModels.CommandLines;
using CommanderMinApi.Application.RequestModels.Platforms;
using CommanderMinApi.Application.ResponseModels;
using CommanderMinApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.MappingProfiles
{
    public class CommanderMinApiProfile : Profile
    {
        public CommanderMinApiProfile()
        {
            CreateMap<CommandLineEntity, UpdateCommandLineRequestModel>().ReverseMap();
            CreateMap<CommandLineEntity, CreateCommandLineRequestModel>().ReverseMap();

            CreateMap<PlatformEntity, CreatePlatformRequestModel>().ReverseMap();
            CreateMap<PlatformEntity, UpdatePlatformRequestModel>().ReverseMap();

            CreateMap<CommandLineEntity, CommandLineResponseDTO>().ReverseMap();
            CreateMap<PlatformEntity, PlatformResponseDTO>().ReverseMap();

            //CreateMap<CommandLineEntity, PlatformResponseDTO>().ReverseMap();
            //CreateMap<List<PlatformResponseDTO>, List<PlatformEntity>>().ReverseMap();
        }
    }
}
