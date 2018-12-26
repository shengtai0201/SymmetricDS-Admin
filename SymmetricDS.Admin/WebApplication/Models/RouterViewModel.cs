using Shengtai;
using SymmetricDS.Admin.Server;
using System.ComponentModel.DataAnnotations;

namespace SymmetricDS.Admin.WebApplication.Models
{
    public class RouterViewModel : ViewModel<int, RouterViewModel, Router>
    {
        [Key]
        public int? Id { get; set; }

        public string RouterId { get; set; }

        public ProjectViewModel Project { get; set; }

        public NodeGroupViewModel SourceNodeGroup { get; set; }

        public NodeGroupViewModel TargetNodeGroup { get; set; }
        public NodeViewModel TargetNode { get; set; }

        protected override RouterViewModel Build(Router entity, object args = null)
        {
            this.Project = ProjectViewModel.NewInstance(entity.Project);
            this.SourceNodeGroup = NodeGroupViewModel.NewInstance(entity.SourceNodeGroup);
            this.TargetNodeGroup = NodeGroupViewModel.NewInstance(entity.TargetNode.NodeGroup);
            this.TargetNode = NodeViewModel.NewInstance(entity.TargetNode);

            return this;
        }
    }
}