using System.Collections.Generic;

namespace SymmetricDS.Admin.Master
{
    public interface INodeSecurityService
    {
        bool CheckRegister(ICollection<string> nodeIds);
    }
}