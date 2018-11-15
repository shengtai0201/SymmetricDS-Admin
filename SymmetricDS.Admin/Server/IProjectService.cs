using SymmetricDS.Admin.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricDS.Admin.Server
{
    public interface IProjectService
    {
        ICollection<ProjectViewModel> Read();
    }
}
