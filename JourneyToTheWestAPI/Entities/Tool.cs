using System;
using System.Collections.Generic;

namespace JourneyToTheWestAPI.Entities
{
    public partial class Tool
    {
        public Tool()
        {
            ToolsInScenarios = new HashSet<ToolsInScenario>();
        }

        public int IdTool { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }

        public virtual ICollection<ToolsInScenario> ToolsInScenarios { get; set; }
    }
}
