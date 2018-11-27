using Shengtai.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace SymmetricDS.Admin
{
    public class AppSettings : IAppSettings<ConnectionStrings>
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public Logging Logging { get; set; }

        public string SymmetricServerPath { get; set; }
        public Databases Database { get; set; }
        public int NodeId { get; set; }
        public int Version { get; set; }
    }
}
