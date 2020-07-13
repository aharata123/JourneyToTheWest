using AutoMapper;
using JourneyToTheWestAPI.Entities;
using JourneyToTheWestAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToTheWestAPI.DAOs
{
    public class RoleInScenarioDAO
    {
        private journeytothewestContext _context;
        private readonly IMapper _mapper;
        public RoleInScenarioDAO(journeytothewestContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<RoleInScenarioDTO>  GetAllRole(int IdScenario)
        {
            var allRole = (from data in _context.RolesInScenarios.Include(s => s.IdActorNavigation)
                           where data.IdScenario == IdScenario
                           select 
                               _mapper.Map<RoleInScenarioDTO>(data)
                               ).ToList();

            return allRole;
        }
    }
}
