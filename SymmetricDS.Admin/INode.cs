using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricDS.Admin
{
    public interface INode
    {
        string ConnectionString { get; }

        bool CopyTo(string path);
        bool Write(string path);
    }
}
