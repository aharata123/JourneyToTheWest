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
    public class ToolDAO
    {
        private journeytothewestContext _context;
        private readonly IMapper _mapper;

        public ToolDAO(journeytothewestContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ToolDTO> getList()
        {
            var tools = (from tool in _context.Tools
                          where tool.Status == (int)Status.ACTIVE
                          select
                              _mapper.Map<ToolDTO>(tool)
                                           ).ToList();
            return tools;
        }

        public ToolDTO getTool(int id)
        {
            var tool = (from t in _context.Tools
                         where t.IdTool == id && t.Status == (int)Status.ACTIVE
                         select _mapper.Map<ToolDTO>(t)).FirstOrDefault();
            return tool;
        }

        public int createTool(ToolDTO dto)
        {
            int id = (int)Constants.FAIL;


            Tool tool = _mapper.Map<Tool>(dto);
            tool.Status = (int)Status.ACTIVE;
            tool.DateCreated = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));

            _context.Tools.Add(tool);
            if (_context.SaveChanges() == (int)Constants.SUCCESS)
            {
                id = tool.IdTool;
            }

            return id;
        }

        public bool updateTool(ToolDTO dto)
        {
            bool isUpdated = false;

            Tool tool = _context.Tools.Find(dto.IdTool);

            if (tool != null)
            {
                _context.Entry(tool).State = EntityState.Detached;
                tool = _mapper.Map<Tool>(dto);
                tool.Status = (int)Status.ACTIVE;

                _context.Entry(tool).State = EntityState.Modified;
                if (_context.SaveChanges() == (int)Constants.SUCCESS)
                {
                    isUpdated = true;
                }
            }
            return isUpdated;
        }

        public bool deleteTool(int id)
        {
            bool isDeleted = false;


            Tool tool = _context.Tools.Find(id);

            if (tool != null)
            {
                tool.Status = (int)Status.DELETED;
                _context.Entry(tool).State = EntityState.Detached;
                _context.Entry(tool).State = EntityState.Modified;
                if (_context.SaveChanges() == (int)Constants.SUCCESS)
                {
                    isDeleted = true;
                }
            }
            return isDeleted;
        }
    }
}
