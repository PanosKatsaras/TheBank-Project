using System;
using System.Collections.Generic;
using TheBank.Entities;
using TheBank.Exceptions;
using TheBank.DataAccessLayer.DALContracts;

namespace TheBank.DataAccessLayer
{
    /// <summary>
    /// Represents data access layer for bank customers 
    /// </summary>
    public class CustomersDataAccessLayer : ICustomersDataAccessLayer
    {
        #region Private Fields
        private static List<Customer> _customers;
        #endregion

        #region Constructors
        static CustomersDataAccessLayer()
        {
            _customers = new List<Customer>();
        }
        #endregion

        #region Properties
        private static List<Customer>Customers
        {
            get => _customers; 
            set => _customers = value; 
        }
        #endregion

        #region Methods
        public List<Customer> GetCustomers()
        {
            try
            {
                List<Customer> customersList = new List<Customer>();
                Customers.ForEach(item => customersList.Add(item.Clone() as Customer));
                return customersList;
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception) 
            {
                throw;
            }
        }

        public List<Customer> GetCustomersByCondition(Predicate<Customer> predicate)
        {
            try
            {
                List<Customer> customersList = new List<Customer>();

                List<Customer> filteredCustomersList = Customers.FindAll(predicate);
                filteredCustomersList.ForEach(item => customersList.Add(item.Clone() as Customer));
                return customersList;
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Guid AddCustomer(Customer customer) 
        {
            try
            {
                Customers.Add(customer);
                customer.CustomerID = Guid.NewGuid();
                return customer.CustomerID;
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                Customer existingCustomer = Customers.Find(item => item.CustomerID == customer.CustomerID);
                if (existingCustomer != null)
                {
                    existingCustomer.CustomerCode = customer.CustomerCode;
                    existingCustomer.CustomerFullName = customer.CustomerFullName;
                    existingCustomer.CustomerAdress = customer.CustomerAdress;
                    existingCustomer.CustomerCity = customer.CustomerCity;
                    existingCustomer.CustomerCountry = customer.CustomerCountry;
                    existingCustomer.CustomerMobile = customer.CustomerMobile;
                    existingCustomer.CustomerEmail = customer.CustomerEmail;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteCustomer(Guid customerID)
        {
            try
            {
                if (Customers.RemoveAll(item => item.CustomerID == customerID) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
