using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyToTheWestAPI.Models
{
    public class ActorDTO
    {
        [JsonProperty("IdActor")]
        public int IdActor { get; set; }
        [JsonProperty("Name")]
        public String Name { get; set; }
        [JsonProperty("Image")]
        public String Image { get; set; }
        [JsonProperty("Description")]
        public String Description { get; set; }
        [JsonProperty("PhoneNumber")]
        public String PhoneNumber { get; set; }
        [JsonProperty("Email")]
        public String Email { get; set; }
        [JsonProperty("password")]
        public String password { get; set; }
        [JsonProperty("username")]
        public String username { get; set; }
        [JsonProperty("role")]
        public int role { get; set; }

    }
}
