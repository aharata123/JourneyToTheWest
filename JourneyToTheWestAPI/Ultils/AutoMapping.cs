using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToTheWestAPI.Ultils
{
    using AutoMapper;
    using JourneyToTheWestAPI.Entities;
    using JourneyToTheWestAPI.Models;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ScenarioDTO, Scenario>()
                .ForMember(
                dest => dest.StartDate,
                opt => opt.MapFrom(src => Convert.ToDateTime(src.StartDate))
                )
                .ForMember(
                dest => dest.EndDate,
                opt => opt.MapFrom(src => Convert.ToDateTime(src.EndDate))
                );


            CreateMap<Scenario, ScenarioDTO>()
                .ForMember(
                dest => dest.StartDate,
                opt => opt.MapFrom(src => src.StartDate.ToString("o"))
                ).ForMember(
                dest => dest.EndDate,
                opt => opt.MapFrom(src => src.EndDate.ToString("o"))
                );


            CreateMap<Actor, ActorDTO>();
            CreateMap<ActorDTO, Actor>();

            CreateMap<Tool, ToolDTO>().ForMember(
                dest => dest.DateCreated,
                opt => opt.MapFrom(src => src.DateCreated.ToString("o"))
                );

            CreateMap<ToolDTO, Tool>().ForMember(
                dest => dest.DateCreated,
                opt => opt.MapFrom(src => src.DateCreated.ToString("o"))
                );

        }
    }

}
