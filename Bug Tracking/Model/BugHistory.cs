using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.Model
{
    /// <summary>
    /// Model to save bug history
    /// </summary>
    class BugHistory
    {
        public int BugHistoryId { get; set; }
        public string Description { get; set; }
        public int SourceControlId { get; set; }
    }
}
