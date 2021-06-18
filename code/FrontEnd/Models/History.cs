﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Models
{
    public class History
    {
        public int ID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Probability { get; set; }
    }
}
