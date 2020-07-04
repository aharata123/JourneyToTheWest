using System;
using System.Collections.Generic;

namespace JourneyToTheWestAPI.Entities
{
    public partial class RolesInScenario
    {
        public int IdScenario { get; set; }
        public int IdRole { get; set; }
        public int Actor { get; set; }

        public virtual Actor ActorNavigation { get; set; }
        public virtual Role IdRoleNavigation { get; set; }
        public virtual Scenario IdScenarioNavigation { get; set; }
    }
}
