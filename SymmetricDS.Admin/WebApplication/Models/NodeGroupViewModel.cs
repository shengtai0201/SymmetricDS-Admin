﻿using Shengtai;
using SymmetricDS.Admin.Server;
using System.ComponentModel.DataAnnotations;

namespace SymmetricDS.Admin.WebApplication.Models
{
    public class NodeGroupViewModel : ViewModel<int, NodeGroupViewModel, NodeGroup>
    {
        [Key]
        public int? Id { get; set; }

        public ProjectViewModel Project { get; set; }

        public string NodeGroupId { get; set; }

        public string Description { get; set; }

        protected override NodeGroupViewModel Build(NodeGroup entity, object args = null)
        {
            this.Project = ProjectViewModel.NewInstance(entity.Project);

            return this;
        }
    }
}