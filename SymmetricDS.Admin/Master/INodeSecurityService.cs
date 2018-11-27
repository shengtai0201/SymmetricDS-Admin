using System;
using System.Collections.Generic;
using System.Text;

namespace SymmetricDS.Admin.Master
{
    public interface INodeSecurityService
    {
        bool CheckRegister(ICollection<string> nodeIds);
    }
}
