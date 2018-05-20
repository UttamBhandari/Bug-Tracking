using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.Model
{
    /// <summary>
    /// Model class for saving information about tester
    /// </summary>
    class Tester
    {
        public int TesterId { get; set; }
        public string Full_name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
