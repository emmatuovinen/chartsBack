using System;
using System.Collections.Generic;

namespace chartback.Models
{
    public partial class Content
    {
        public int ContentId { get; set; }
        public string ValueX { get; set; }
        public string ValueY { get; set; }
        public string ValueZ { get; set; }
        public int ChartId { get; set; }

        public Chart Chart { get; set; }
    }
}
