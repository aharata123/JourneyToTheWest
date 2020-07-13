using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToTheWestAPI.Models
{
    public class RoleInScenarioDTO
    {
        [JsonProperty("IdScenario")]
        public int IdScenario { get; set; }
        [JsonProperty("RoleName")]
        public String RoleName { get; set; }
        [JsonProperty("IdActor")]
        public int IdActor { get; set; }
        [JsonProperty("NameActor")]
        public String NameActor { get; set; }
        [JsonProperty("Image")]
        public String Image { get; set; }
    }
}
