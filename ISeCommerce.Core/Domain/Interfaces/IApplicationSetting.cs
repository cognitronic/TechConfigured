using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISeCommerce.Core.Domain.Interfaces
{
    public interface IApplicationSetting
    {
        int ID { get; set; }
        string Setting { get; set; }
        string Description { get; set; }
        string ImagePath { get; set; }
        string Value { get; set; }
        int ApplicationID { get; set; }
        string AltTag { get; set; }
        string URL { get; set; }
    }
}
