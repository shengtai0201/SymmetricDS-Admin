using Shengtai.Options;
using System.Collections.Generic;

namespace SymmetricDS.Admin
{
    public class AppSettings : AppSettings<ConnectionStrings>
    {
        public class Node
        {
            public int Id { get; set; }
            public int Version { get; set; }
        }

        public string SymmetricServerPath { get; set; }
        public Databases Database { get; set; }
        public ICollection<Node> Nodes { get; set; }
    }
}