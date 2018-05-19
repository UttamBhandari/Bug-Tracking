using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.Model
{
    /// <summary>
    /// model to save about bug information
    /// </summary>
    class BugInformation
    {
        public int? InformationId { get; set; }
        public int BugId { get; set; }
        public string Cause { get; set; }
        public string Symtons { get; set; }
    }
}
