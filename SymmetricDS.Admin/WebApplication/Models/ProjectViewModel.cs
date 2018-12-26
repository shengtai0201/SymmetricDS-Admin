using Shengtai;
using SymmetricDS.Admin.Server;
using System.ComponentModel.DataAnnotations;

namespace SymmetricDS.Admin.WebApplication.Models
{
    public class ProjectViewModel : ViewModel<int, ProjectViewModel, Project>
    {
        [Key]
        public int? Id { get; set; }

        public string Name { get; set; }
    }
}