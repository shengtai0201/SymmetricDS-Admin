using Shengtai;
using SymmetricDS.Admin.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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

        public override RouterViewModel Build(Router entity)
        {
            this.Project = ProjectViewModel.NewInstance(entity.Project);
            this.SourceNodeGroup = NodeGroupViewModel.NewInstance(entity.SourceNodeGroup).Build(entity.SourceNodeGroup);
            this.TargetNodeGroup = NodeGroupViewModel.NewInstance(entity.TargetNodeGroup).Build(entity.TargetNodeGroup);

            return this;
        }
    }
}
