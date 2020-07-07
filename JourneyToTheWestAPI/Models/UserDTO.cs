using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToTheWestAPI.Models
{
    public class UserDTO
    {
        public ActorDTO actor { get; set; }
        [JsonProperty("role")]
        public int Role { get; set; }
    }
}
