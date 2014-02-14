using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;
using ISeCommerce.Core.Domain;
using ISeCommerce.Core.Domain.Interfaces;

namespace ISeCommerce.AdminPresenters.ViewInterfaces
{
    public interface ICategorySpecificationsView : IView 
    {
        IList<ProductCategorySpecificationProperty> SpecificationsResultSet { get; set; }
        IList<ProductCategorySpecificationPropertyValue> ValuesResultSet { get; set; }
        event EventHandler<IdeaSeedGridArgs> OnGetSpecifications;
        event EventHandler<IdeaSeedGridItemEventArgs> OnSpecificationsDataBound;
        event EventHandler<IdeaSeedLinkButtonArgs> OnSpecificationSelected;
        event EventHandler<IdeaSeedGridArgs> OnGetValues;
        event EventHandler<IdeaSeedGridItemEventArgs> OnValuesDataBound;
        void LoadSpecifications(IdeaSeedGridArgs args);
        void LoadValues(IdeaSeedGridArgs args);
        void NavigateTo(string url);
        int SelectedPropertyID { get; set; }
    }
}
