using Shengtai.Web.Telerik;
using SymmetricDS.Admin.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SymmetricDS.Admin.Server
{
    public interface INodeService
    {
        ICollection<NodeViewModel> Read(IFilterInfoCollection serverFiltering);
    }
}
