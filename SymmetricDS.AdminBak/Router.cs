﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricDS.Admin
{
    public class Router
    {
        public string RouterId { get; set; }
        public NodeGroup Source { get; set; }
        public NodeGroup Target { get; set; }
    }
}