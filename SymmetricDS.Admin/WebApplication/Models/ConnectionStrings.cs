using Shengtai.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace SymmetricDS.Admin.WebApplication.Models
{
    public class ConnectionStrings : IDefaultConnection
    {
        public string DefaultConnection { get; set; }
    }
}
