using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JourneyToTheWestAPI.DAOs;
using JourneyToTheWestAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace JourneyToTheWestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private RoleInScenarioDAO dao;

        public ShoppingCartController(RoleInScenarioDAO dao)
        {
            this.dao = dao;
        }


        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var data = dao.GetAllRole(id);
            if (data == null)
            {
                return StatusCode(404);
            }
            else return StatusCode(200, data);
        }

        [HttpPost("roles")]
        public ActionResult Post([FromBody] List<RoleScenarioDTO> list)
        {

            bool isAdd = dao.addRoleToScenario(list);

            if (!isAdd)
            {
                return StatusCode(400);
            }
            else return StatusCode(204);
        }

        [HttpDelete("roles")]
        public ActionResult Delete([FromBody] List<RoleScenarioDTO> list)
        {

            bool isDelete = dao.deleteRoleToScenario(list);

            if (!isDelete)
            {
                return StatusCode(400);
            }
            else return StatusCode(204);
        }

        [HttpGet("tool/{id}")]
        public ActionResult GetTool(int id)
        {
            var data = dao.GetAllTool(id);
            if (data == null)
            {
                return StatusCode(404);
            }
            else return StatusCode(200, data);
        }



    }
}
