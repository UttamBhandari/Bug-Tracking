using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.Model
{
    /// <summary>
    /// Model class for saving code
    /// </summary>
    class SourceCode
    {
        public int CodeId { get; set; }
        public string CodeFilePath { get; set; }
        public string CodeFileName { get; set; }
        public string ProgrammingLanguage { get; set; }
        public int BugId { get; set; }
    }
}
