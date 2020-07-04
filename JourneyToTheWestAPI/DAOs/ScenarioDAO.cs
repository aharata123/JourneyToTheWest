using AutoMapper;
using JourneyToTheWestAPI.Entities;
using JourneyToTheWestAPI.Enums;
using JourneyToTheWestAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToTheWestAPI.DAOs
{
    public class ScenarioDAO
    {
        private journeytothewestContext _context;
        private readonly IMapper _mapper;

        public ScenarioDAO(journeytothewestContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ScenarioDTO> getList()
        {
            var scenarios = (from scenario in _context.Scenarios
                                           where scenario.Status == (int)Status.ACTIVE
                                           select 
                                               _mapper.Map<ScenarioDTO>(scenario)
                                           ).ToList();
            return scenarios;
        }

        public int createScenario(ScenarioDTO dto)
        {
            int id = (int) Constants.FAIL;


            Scenario scene = _mapper.Map<Scenario>(dto);
            scene.Status = (int)Status.ACTIVE;
            _context.Scenarios.Add(scene);
            if(_context.SaveChanges() == (int)Constants.SUCCESS)
            {
                id = scene.IdScenario;
            }

            return id;
        }

        public bool updateScenario(ScenarioDTO dto)
        {
            bool isUpdated = false;

            Scenario scenario = _context.Scenarios.Find(dto.IdScenario);            

            if(scenario != null)
            {
                _context.Entry(scenario).State = EntityState.Detached;
                scenario = _mapper.Map<Scenario>(dto);
                scenario.Status = (int)Status.ACTIVE;
                _context.Entry(scenario).State = EntityState.Modified;
                if (_context.SaveChanges() == (int)Constants.SUCCESS)
                {
                    isUpdated = true;
                }
            }   
            return isUpdated;
        }

        public bool deleteScenario(int id)
        {
            bool isDeleted = false;


            Scenario scenario = _context.Scenarios.Find(id);

            if (scenario != null)
            {
                scenario.Status = (int)Status.DELETED;
                _context.Entry(scenario).State = EntityState.Detached;
                _context.Entry(scenario).State = EntityState.Modified;
                if (_context.SaveChanges() == (int)Constants.SUCCESS)
                {
                    isDeleted = true;
                }
            }
            return isDeleted;
        }
    }
}
