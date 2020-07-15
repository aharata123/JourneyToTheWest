using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToTheWestAPI.Models
{
    public class ToolScenarioDTO
    {
        [JsonProperty("IdScenario")]
        public int IdScenario { get; set; }
        [JsonProperty("Quantity")]
        public int quantity { get; set; }
        [JsonProperty("IdTool")]
        public int IdTool { get; set; }
    }
}
