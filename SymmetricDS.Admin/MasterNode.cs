using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricDS.Admin
{
    public class MasterNode : Node, IMaster
    {
        public MasterNode(Databases database, string dbHost, string db, string dbUser, string dbPassword, string syncUrlPort, NodeGroup group, string externalId, int jobPurgePeriodTimeMs = 7200000, int jobRoutingPeriodTimeMs = 5000, int jobPushPeriodTimeMs = 10000, int jobPullPeriodTimeMs = 10000, bool initialLoadCreateFirst = true) : base(database, dbHost, db, dbUser, dbPassword, syncUrlPort, group, externalId, jobPurgePeriodTimeMs, jobRoutingPeriodTimeMs, jobPushPeriodTimeMs, jobPullPeriodTimeMs, initialLoadCreateFirst)
        {
        }

        public IMaster Add()
        {
            throw new NotImplementedException();
        }
    }
}
