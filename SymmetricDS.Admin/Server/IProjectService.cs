using SymmetricDS.Admin.WebApplication.Models;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Server
{
    public interface IProjectService
    {
        ICollection<ProjectViewModel> Read();
    }
}