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

        public ProjectViewModel SourceProject { get; set; }
        public NodeGroupViewModel SourceNodeGroup { get; set; }

        public ProjectViewModel TargetProject { get; set; }
        public NodeGroupViewModel TargetNodeGroup { get; set; }

        public override RouterViewModel Build(Router entity)
        {
            this.SourceNodeGroup = NodeGroupViewModel.NewInstance(entity.SourceNodeGroup).Build(entity.SourceNodeGroup);
            this.SourceProject = this.SourceNodeGroup.Project;

            this.TargetNodeGroup = NodeGroupViewModel.NewInstance(entity.TargetNodeGroup).Build(entity.TargetNodeGroup);
            this.TargetProject = this.TargetNodeGroup.Project;

            return this;
        }
    }
}
