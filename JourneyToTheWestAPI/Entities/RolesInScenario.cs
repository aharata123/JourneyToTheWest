using System;
using System.Collections.Generic;

namespace JourneyToTheWestAPI.Entities
{
    public partial class RolesInScenario
    {
        public int IdScenario { get; set; }
        public string RoleName { get; set; }
        public int IdActor { get; set; }

        public virtual Actor IdActorNavigation { get; set; }
        public virtual Scenario IdScenarioNavigation { get; set; }
    }
}
