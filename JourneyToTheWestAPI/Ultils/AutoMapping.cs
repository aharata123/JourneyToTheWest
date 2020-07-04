using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToTheWestAPI.Ultils
{
    using AutoMapper;
    using JourneyToTheWestAPI.Entities;
    using JourneyToTheWestAPI.Models;

    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ScenarioDTO, Scenario>();
            CreateMap<Scenario, ScenarioDTO>();
        }
    }
}
