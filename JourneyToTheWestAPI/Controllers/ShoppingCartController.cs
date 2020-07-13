using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JourneyToTheWestAPI.DAOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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



    }
}
