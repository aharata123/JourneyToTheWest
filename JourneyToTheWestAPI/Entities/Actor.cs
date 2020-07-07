using System;
using System.Collections.Generic;

namespace JourneyToTheWestAPI.Entities
{
    public partial class Actor
    {
        public Actor()
        {
            Roles = new HashSet<Role>();
            RolesInScenarios = new HashSet<RolesInScenario>();
        }

        public int IdActor { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public int Status { get; set; }
        public int Role { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<RolesInScenario> RolesInScenarios { get; set; }
    }
}
