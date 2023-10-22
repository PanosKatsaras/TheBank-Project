using System;
using System.Collections.Generic;
using TheBank.BusinessLogicLayer.BALContracts;
using TheBank.DataAccessLayer;
using TheBank.DataAccessLayer.DALContracts;
using TheBank.Entities;
using TheBank.Exceptions;

namespace TheBank.BusinessLogicLayer
{
    /// <summary>
    /// Class that represents business logic layer
    /// </summary>
    public class CustomersBusinessLogicLayer:ICustomersBusinessLogicLayer
    {
        private ICustomersDataAccessLayer _customersDataAccessLayer;

        #region Constructors
        public CustomersBusinessLogicLayer()
        {
            _customersDataAccessLayer = new CustomersDataAccessLayer();
        }
        #endregion

        private ICustomersDataAccessLayer CustomersDataAccessLayer
        {
            set => _customersDataAccessLayer = value;
            get => _customersDataAccessLayer;
        }

        /// <summary>
        /// Method that gets a list of customers
        /// </summary>
        /// <returns></returns>
 
        #region Methods
        public List<Customer> GetCustomers()
        {
            try
            {
                return CustomersDataAccessLayer.GetCustomers();
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

        /// <summary>
        /// Method that gets customers by condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<Customer> GetCustomersByCondition(Predicate<Customer> predicate)
        {
            try
            {
                return CustomersDataAccessLayer.GetCustomersByCondition(predicate);
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

        /// <summary>
        /// Method that adds a customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public Guid AddCustomer(Customer customer)
        {
            try
            {
                List<Customer> allCustomers = CustomersDataAccessLayer.GetCustomers();
                long maxCustomerCode = 0;
                foreach (var item in allCustomers)
                {
                    if (item.CustomerCode > maxCustomerCode)
                    {
                        maxCustomerCode = item.CustomerCode;
                    }
                }
                if (allCustomers.Count >= 1)
                {
                    customer.CustomerCode = maxCustomerCode + 1;
                }
                else
                {
                    customer.CustomerCode = TheBank.Configuration.Settings.BaseCustomerNo + 1;
                }
                
                return CustomersDataAccessLayer.AddCustomer(customer);
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

        /// <summary>
        /// Method that updates a customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                return CustomersDataAccessLayer.UpdateCustomer(customer);
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

        /// <summary>
        /// Method that deletes a customer
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public bool DeleteCustomer(Guid customerID)
        {
            try
            {
                return CustomersDataAccessLayer.DeleteCustomer(customerID);
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
