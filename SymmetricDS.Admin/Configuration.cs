using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricDS.Admin
{
    public class Configuration
    {
        public string EngineName { get; set; }
        public string DbDriver { get; set; }
        public string DbUrl { get; set; }
        public string DbUser { get; set; }
        public string DbPassword { get; set; }
        public string RegistrationUrl { get; set; }
        public string SyncUrl { get; set; }
        public string GroupId { get; set; }
        public string ExternalId { get; set; }
        public int JobPurgePeriodTimeMs { get; set; }
        public int JobRoutingPeriodTimeMs { get; set; }
        public int JobPushPeriodTimeMs { get; set; }
        public int JobPullPeriodTimeMs { get; set; }
        public bool InitialLoadCreateFirst { get; set; }
    }
}
