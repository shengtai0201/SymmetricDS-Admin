using Shengtai;
using SymmetricDS.Admin.Server;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SymmetricDS.Admin.WebApplication.Models
{
    public class NodeViewModel : ViewModel<int, NodeViewModel, Node>
    {
        [Key]
        public int? Id { get; set; }

        public NodeGroupViewModel NodeGroup { get; set; }

        public KeyValuePair<int, string> DatabaseType { get; set; }
        public string DatabaseHost { get; set; }
        public string DatabaseName { get; set; }
        public string DatabaseUser { get; set; }
        public string DatabasePassword { get; set; }

        public string SyncUrlPort { get; set; }
        public string ExternalId { get; set; }

        public int JobPurgePeriodTimeMs { get; set; }
        public int JobRoutingPeriodTimeMs { get; set; }
        public int JobPushPeriodTimeMs { get; set; }
        public int JobPullPeriodTimeMs { get; set; }

        public bool InitialLoadCreateFirst { get; set; }
        public string NodePassword { get; set; }
        public int Version { get; set; }

        protected override NodeViewModel Build(Node entity, object args = null)
        {
            this.NodeGroup = NodeGroupViewModel.NewInstance(entity.NodeGroup);
            this.DatabaseType = entity.DatabaseType.GetEnumKeyValue();

            return this;
        }
    }
}