using System;
using System.Collections.Generic;

namespace chartback.Models
{
    public partial class Chart
    {
        public Chart()
        {
            Content = new HashSet<Content>();
        }

        public int ChartId { get; set; }
        public string Headline { get; set; }
        public string Description { get; set; }

        public ICollection<Content> Content { get; set; }

    }
}
