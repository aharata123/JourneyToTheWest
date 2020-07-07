using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToTheWestAPI.Models
{
    public class LoginDTO
    {
        [JsonProperty("username")]
        public String username { get; set; }
        [JsonProperty("password")]
        public String password { get; set; }
    }
}
