using AutoMapper;
using CommanderMinApi.Application.RequestModels.CommandLines;
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

        }
    }
}
