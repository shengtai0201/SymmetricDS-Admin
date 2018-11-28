using Shengtai.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace SymmetricDS.Admin
{
    public class AppSettings : IAppSettings<ConnectionStrings>
    {
        public class Node
        {
            public int Id { get; set; }
            public int Version { get; set; }
        }

        public ConnectionStrings ConnectionStrings { get; set; }
        public Logging Logging { get; set; }

        public string SymmetricServerPath { get; set; }
        public Databases Database { get; set; }
        public ICollection<Node> Nodes { get; set; }
    }
}
