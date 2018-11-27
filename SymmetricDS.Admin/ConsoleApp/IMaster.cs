using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricDS.Admin.ConsoleApp
{
    public interface IMaster
    {
        // Step 1.註冊Client Node
        ICollection<string> Register(string path, IConfiguration configuration);
    }
}
