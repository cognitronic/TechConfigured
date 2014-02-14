using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.Presenters.ViewInterfaces
{
    public interface IFullWidthPageView : IView
    {
        event EventHandler OnLoadData;
        IList<IPageApplicationView> MainContentViews { get; set; }
    }
}
