using Shengtai.Web.Telerik;
using SymmetricDS.Admin.WebApplication.Models;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Server
{
    public interface INodeService
    {
        ICollection<NodeViewModel> Read(IFilterInfoCollection serverFiltering);
    }
}