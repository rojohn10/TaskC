﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskC.Models
{
    public class IncidentForm
    {
        public string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty; 
    }
}
