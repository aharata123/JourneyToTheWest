using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToTheWestAPI.Models
{
    public class RoleScenarioDTO
    {
        [JsonProperty("IdScenario")]
        public int IdScenario { get; set; }
        [JsonProperty("RoleName")]
        public String RoleName { get; set; }
        [JsonProperty("IdActor")]
        public int IdActor { get; set; }
    }
}
