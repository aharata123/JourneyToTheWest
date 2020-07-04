using JourneyToTheWestAPI.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToTheWestAPI.Models
{
    public class ScenarioDTO
    {
        [JsonProperty("IdScenario")]
        public int? IdScenario { get; set; }
        [JsonProperty("ScenarioName")]
        public String ScenarioName { get; set; }
        [JsonProperty("Description")]
        public String Description { get; set; }
        [JsonProperty("Location")]
        public String Location { get; set; }
        [JsonProperty("StartDate")]
        public String StartDate { get; set; }
        [JsonProperty("EndDate")]
        public String EndDate { get; set; }
        [JsonProperty("TimeRecord")]
        public int TimeRecord { get; set; }

    }
}
