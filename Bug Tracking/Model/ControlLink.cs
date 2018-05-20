using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.Model
{
    /// <summary>
    /// Model for saving details about source control
    /// </summary>
    class ControlLink
    {
        public int? LinkID { get; set; }
        public string CodeLink { get; set; }
        public int StartLine { get; set; }
        public int EndLine { get; set; }
        public int? BugId { get; set; }
    }
}
