using System;
using TheBank.Entities;
using System.Collections.Generic;

namespace TheBank.DataAccessLayer.DALContracts
{
    /// <summary>
    /// Interface that represents customers data access layer
    /// </summary>
    public interface ICustomersDataAccessLayer
    {
        List<Customer> GetCustomers();

        List<Customer> GetCustomersByCondition(Predicate<Customer> predicate);

        Guid AddCustomer(Customer customer);

        bool UpdateCustomer(Customer customer);
        
        bool DeleteCustomer(Guid customerID);
    }
}
