using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISeCommerce.Core.Domain.Interfaces
{
    public interface ICustomer : IItem
    {
        int ID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string PasswordQuestion { get; set; }
        string PasswordAnswer { get; set; }
        DateTime DateRegistered { get; set; }
        string WorkPhone { get; set; }
        string CellPhone { get; set; }
        string HomePhone { get; set; }
        bool IsActive { get; set; }
        string Avatar { get; set; }
    }
}
