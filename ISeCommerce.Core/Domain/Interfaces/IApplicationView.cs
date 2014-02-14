﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;

namespace ISeCommerce.Core.Domain.Interfaces
{
    public interface IApplicationView
    {
        int ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Path { get; set; }
        AccessLevels AccessLevel { get; set; }
    }
}
