using Shengtai.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace SymmetricDS.Admin.WebApplication.Models
{
    public class AppSettings : IAppSettings<ConnectionStrings>
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public string DateTimeOffsetFormat { get; set; } = "yyyy-MM-dd HH:mmzzz";


    }
}
