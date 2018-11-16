using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricDS.Admin.ConsoleApp
{
    public interface INode
    {
        int Version { get; }

        //string ConnectionString { get; }

        bool CopyTo(string path);
        //bool Write(string path);
    }
}
