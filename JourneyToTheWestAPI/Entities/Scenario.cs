using JourneyToTheWestAPI.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace JourneyToTheWestAPI.Entities
{
    public partial class Scenario
    {
        public Scenario()
        {
            RolesInScenarios = new HashSet<RolesInScenario>();
            ToolsInScenarios = new HashSet<ToolsInScenario>();
        }

        public int IdScenario { get; set; }
        public string ScenarioName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TimeRecord { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<RolesInScenario> RolesInScenarios { get; set; }
        public virtual ICollection<ToolsInScenario> ToolsInScenarios { get; set; }
    }
}
