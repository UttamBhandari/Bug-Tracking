using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.Model
{
    /// <summary>
    /// Model to save about code fixer
    /// </summary>
    class Fixer
    {
        public int FixerId { get; set; }
        public int FixedBy { get; set; }
        public int BugId { get; set; }
        public DateTime FixedDate { get; set; }
        public Programmer programmer { get; set; }
    }
}
