﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core.Data;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.Core.Domain.Interfaces.Data
{
    public interface IPageRepository : IRepository<Page, int>
    {
        Page GetByURL(string url);
        IList<Page> GetChildPagesByParentID(int parentID);
    }
}