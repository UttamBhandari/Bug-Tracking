using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.Model
{
    /// <summary>
    /// Model class used for tracking bug
    /// </summary>
    class Bug
    {
        public int BugId { get; set; }
        public string ProjectName { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public int StartLine { get; set; }
        public int EndLine { get; set; }
        public int ProgrammerId { get; set; }
        public string Status { get; set; }
        public BugImage Images { get; set; }
        public SourceCode Codes { get; set; }
        public SourceLink SourceControl { get; set; }
    }
}
