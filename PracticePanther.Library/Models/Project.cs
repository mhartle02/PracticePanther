﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePanther.Library.Models
{
    public class Project
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client? Client { get; set; }
        public string? Name { get; set; }
        public string? IsActive { get; set; }

       

        public override string ToString()
        {
            return $"{Name}        (Status: {IsActive})";
        }
    }
}

