using System;
using System.Collections.Generic;
using TheBank.Entities;

namespace TheBank.BusinessLogicLayer.BALContracts
{
    /// <summary>
    /// Interface that represents business logic layer
    /// </summary>
    public interface ICustomersBusinessLogicLayer
    {
        List<Customer> GetCustomers();

        List<Customer> GetCustomersByCondition(Predicate<Customer> predicate);

        Guid AddCustomer(Customer customer);

        bool UpdateCustomer(Customer customer);

        bool DeleteCustomer(Guid customerID);

    }
}
