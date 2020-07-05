using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
    public class ScenarioController : ControllerBase
    {
        private ScenarioDAO dao;

        public ScenarioController(ScenarioDAO dao)
        {
            this.dao = dao;
        }
        // GET: api/<ScenarioController>
        [HttpGet]
        public IEnumerable<ScenarioDTO> Get()
        {
            return dao.getList();
        }

        // GET api/<ScenarioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ScenarioController>
        [HttpPost]
        public ActionResult Post([FromForm] ScenarioDTO dto)
        {
            Console.WriteLine(dto);
            int id = dao.createScenario(dto);
            if(id == (int)Constants.FAIL)
            {
                
            }
            return StatusCode(201);
        }

        // PUT api/<ScenarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put([FromForm] ScenarioDTO dto)
        {
            if (dao.updateScenario(dto))
            {
                return StatusCode(200);
            } else
            {
                return StatusCode(400);
            }
        }

        // DELETE api/<ScenarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            if (dao.deleteScenario(id))
            {
                return StatusCode(200);
            } else
            {
                return StatusCode(400);
            }

        }
    }
}
