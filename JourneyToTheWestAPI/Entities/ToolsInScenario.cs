using System;
using System.Collections.Generic;

namespace JourneyToTheWestAPI.Entities
{
    public partial class ToolsInScenario
    {
        public int IdTool { get; set; }
        public int IdScenario { get; set; }
        public int Quantity { get; set; }

        public virtual Scenario IdScenarioNavigation { get; set; }
        public virtual Tool IdToolNavigation { get; set; }
    }
}
