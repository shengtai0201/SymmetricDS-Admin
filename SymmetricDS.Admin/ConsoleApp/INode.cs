using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricDS.Admin.ConsoleApp
{
    public interface INode
    {
        int ProjectId { get; }
        string ExternalId { get; }
        string GroupId { get; }
        string Password { get; }
        int Version { get; }

        IMaster MasterNode { get; }

        bool CopyTo(string path);
        bool Write(string path);

        // Step 2.啟動服務
        void RunOnlyOnce(string path);
        void InstallService(string path);
        void UninstallService(string path);
        void StopService(string path);
        void StartService(string path);
    }
}
