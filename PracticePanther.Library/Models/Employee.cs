﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracticePanther.Library.Models
{

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public string? Status { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} (Hourly Rate: {Rate}) **{Status}**";
        }
    }
}