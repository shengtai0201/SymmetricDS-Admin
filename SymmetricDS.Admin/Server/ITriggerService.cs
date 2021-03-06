﻿using Shengtai.Web.Telerik;
using SymmetricDS.Admin.WebApplication.Models;
using System.Collections.Generic;

namespace SymmetricDS.Admin.Server
{
    public interface ITriggerService
    {
        ICollection<TriggerViewModel> Read(IFilterInfoCollection serverFiltering);
    }
}