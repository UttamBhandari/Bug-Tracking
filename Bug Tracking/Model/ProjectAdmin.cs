﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.Model
{
    class ProjectAdmin
    {
        public int? AdminId { get; set; }
        public string Organization { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
