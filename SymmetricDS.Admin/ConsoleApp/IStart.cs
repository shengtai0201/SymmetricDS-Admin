using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricDS.Admin.ConsoleApp
{
    public interface IStart
    {
        // Step 1.註冊Client Node
        void Register();

        // Step 2.啟動服務
        void Start();
    }
}
