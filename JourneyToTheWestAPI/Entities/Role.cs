using System;
using System.Collections.Generic;

namespace JourneyToTheWestAPI.Entities
{
    public partial class Role
    {
        public Role()
        {
            RolesInScenarios = new HashSet<RolesInScenario>();
        }

        public int IdRole { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public int IdActor { get; set; }

        public virtual Actor IdActorNavigation { get; set; }
        public virtual ICollection<RolesInScenario> RolesInScenarios { get; set; }
    }
}
