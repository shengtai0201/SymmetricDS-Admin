using SymmetricDS.Admin.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricDS.Admin.WebApplication.Models
{
    public class ProjectViewModel : ViewModel<int, ProjectViewModel, Project>
    {
        [Key]
        public int? Id { get; set; }
    }
}
