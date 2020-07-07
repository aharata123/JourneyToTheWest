using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JourneyToTheWestAPI.DAOs;
using JourneyToTheWestAPI.Entities;
using JourneyToTheWestAPI.Enums;
using JourneyToTheWestAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JourneyToTheWestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolController : ControllerBase
    {
        private ToolDAO dao;

        public ToolController(ToolDAO dao)
        {
            this.dao = dao;
        }
        // GET: api/<ScenarioController>
        [HttpGet]
        public IEnumerable<ToolDTO> Get()
        {
            return dao.getList();
        }

        // GET api/<ScenarioController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            ToolDTO dto = dao.getTool(id);
            if (dto != null)
            {
                return StatusCode(200, dto);
            }
            else
            {
                return StatusCode(404);
            }
        }

        // POST api/<ScenarioController>
        [HttpPost]
        public ActionResult Post([FromForm] ToolDTO dto)
        {
            Console.WriteLine(dto);
            int id = dao.createTool(dto);
            if (id == (int)Constants.FAIL)
            {
                return StatusCode(500);
            }
            return StatusCode(201);
        }

        // PUT api/<ScenarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put([FromForm] ToolDTO dto)
        {
            if (dao.updateTool(dto))
            {
                return StatusCode(200);
            }
            else
            {
                return StatusCode(400);
            }
        }

        // DELETE api/<ScenarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            if (dao.deleteTool(id))
            {
                return StatusCode(200);
            }
            else
            {
                return StatusCode(400);
            }

        }
    }
}
