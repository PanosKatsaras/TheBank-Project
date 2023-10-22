using System;
using System.Text.RegularExpressions;
using TheBank.Entities.Contracts;
using TheBank.Exceptions;

namespace TheBank.Entities
{
    /// <summary>
    /// Class that represents customer of the bank
    /// </summary>
    public class Customer:ICustomer,ICloneable
    {
        #region Private Fields
        private Guid _customerID;
        private long _customerCode;
        private string _customerFullName;
        private string _customerAdress;
        private string _customeCity;
        private string _customeCountry;
        private string _customerMobile;
        private string _customerEmail;
        #endregion

        #region Properties
        /// <summary>
        /// GUID of customer for unique identification
        /// </summary>
        public Guid CustomerID { get => _customerID; set => _customerID = value; }
        /// <summary>
        /// Auto-generated code number of customer
        /// </summary>
        public long CustomerCode 
        { 
            get => _customerCode; 
            set
            {
                if (value > 0)
                {
                    _customerCode = value;
                }
                else
                {
                    throw new CustomerException("Customer code should be positive number only.");
                }
            }
        }
        /// <summary>
        /// Full name of the customer
        /// </summary>
        public string CustomerFullName 
        { 
            get => _customerFullName;
            set 
            { 
                if(value.Length <= 40 && string.IsNullOrEmpty(value) == false)
                {
                    _customerFullName = value;
                }
                else
                {
                    throw new CustomerException("Customer name should not be empty and not more than 40 characters long.");
                }
            }
        }
        /// <summary>
        /// Addrress of the customer
        /// </summary>
        public string CustomerAdress { get => _customerAdress; set => _customerAdress = value; }
        /// <summary>
        /// City of the customer
        /// </summary>
        public string CustomerCity { get => _customeCity; set => _customeCity = value; }
        /// <summary>
        /// Country of the customer
        /// </summary>
        public string CustomerCountry { get => _customeCountry; set => _customeCountry = value; }
        /// <summary>
        /// 10-digit mobile number of the customer
        /// </summary>
        public string CustomerMobile 
        { get => _customerMobile;
            set 
            {
                Regex regex = new Regex("^[0-9]*$");
                bool result = regex.IsMatch(value); 

                if(value.Length == 10 && result == true)
                {
                    _customerMobile = value;
                }
                else
                {
                    throw new CustomerException("Mobile number should be only 10-digit number.");
                }
            } 
        }
        /// <summary>
        /// Email address of the customer
        /// </summary>
        public string CustomerEmail 
        { 
            get => _customerEmail;
            set
            {
                Regex regex = new Regex("^\\S+@\\S+\\.\\S+$");
                bool result = regex.IsMatch(value);
                if (result == true)
                {
                    _customerEmail = value;
                }
                else
                {
                    throw new CustomerException("Enter an email adress!");
                }
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Method that creates a copy of Customer
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Customer() { CustomerID = this.CustomerID, CustomerCode = this.CustomerCode,
                CustomerFullName = this.CustomerFullName, CustomerAdress = this.CustomerAdress, 
                CustomerCity = this.CustomerCity,CustomerCountry = this.CustomerCountry, 
                CustomerMobile = this.CustomerMobile, CustomerEmail = this.CustomerEmail
            };
        }
        #endregion
    }
}
