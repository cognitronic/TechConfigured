using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISeCommerce.Core.Domain.Interfaces
{
    public interface IQuickLink
    {
        string Title{ get; set; }
        string URL { get; set; }
        string IconPath { get; set; }
    }
}
