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

    public class ActorController : ControllerBase
    {
        private ActorDAO dao;

        public ActorController(ActorDAO dao)
        {
            this.dao = dao;
        }
        // GET: api/<ScenarioController>



        [HttpGet]
        public IEnumerable<ActorDTO> Get()
        {
            return dao.getList();
        }

        // GET api/<ScenarioController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            ActorDTO dto = dao.getActor(id);
            if(dto != null)
            {
                return StatusCode(200, dto);
            }
            else { 
                return StatusCode(404); 
            }
        }

        // POST api/<ScenarioController>
        [HttpPost]
        public ActionResult Post([FromForm] ActorDTO dto)
        {
            Console.WriteLine(dto);
            int id = dao.createActor(dto);
            if (id == (int)Constants.FAIL)
            {
                return StatusCode(500);
            }
            return StatusCode(201);
        }

        // PUT api/<ScenarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put([FromForm] ActorDTO dto)
        {
            if (dao.updateActor(dto))
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

            if (dao.deleteActor(id))
            {
                return StatusCode(200);
            }
            else
            {
                return StatusCode(400);
            }

        }

        [HttpPost("login")]
        public ActionResult<ActorDTO> Post([FromForm] LoginDTO dto)
        {
            ActorDTO actor = dao.login(dto.username, dto.password);
            
            
            if (actor == null)
            {
                return StatusCode(404);
            }
            return actor;
        }

    }

}
