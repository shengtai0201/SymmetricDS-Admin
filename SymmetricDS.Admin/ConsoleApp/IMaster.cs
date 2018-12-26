using System.Collections.Generic;

namespace SymmetricDS.Admin.ConsoleApp
{
    public interface IMaster
    {
        // Step 1.註冊Client Node
        ICollection<string> Register(string path, IConfiguration configuration);
    }
}