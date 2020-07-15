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
            if(allRole.Count == 0)
            {
                allRole = null;
            }

            return allRole;
        }

        public bool addRoleToScenario(List<RoleScenarioDTO> dto)
        {
            bool isAdd = false;

            foreach(var item in dto)
            {
                RolesInScenario roles = _mapper.Map<RolesInScenario>(item);
                try
                {
                    _context.RolesInScenarios.Add(roles);
                } catch (Exception e)
                {
                    // check trùng key
                    return false;
                }
                
            }
                
            if (_context.SaveChanges() == dto.Count)
            {
                isAdd = true;
            }

            return isAdd;
        }

        public bool deleteRoleToScenario(List<RoleScenarioDTO> dto)
        {
            bool isDelete = false;

            foreach (var item in dto)
            {
                RolesInScenario roles = _mapper.Map<RolesInScenario>(item);
                try
                {
                    _context.RolesInScenarios.Remove(roles);
                }
                catch (Exception e)
                {
                    // check trùng key
                    return false;
                }

            }

            if (_context.SaveChanges() == dto.Count)
            {
                isDelete = true;
            }

            return isDelete;
        }


        public List<ToolInScenarioDTO> GetAllTool(int IdScenario)
        {
            var allTool = (from data in _context.ToolsInScenarios.Include(s => s.IdToolNavigation)
                           where data.IdScenario == IdScenario
                           select
                               _mapper.Map<ToolInScenarioDTO>(data)
                               ).ToList();
            if (allTool.Count == 0)
            {
                allTool = null;
            }

            return allTool;
        }


    }
}
