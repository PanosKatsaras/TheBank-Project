using System;
using TheBank.Exceptions;
using TheBank.Entities.Contracts;

namespace TheBank.Entities
{
    /// <summary>
    /// Represents account of the bank
    /// </summary>
    public class Account:IAccount,ICloneable
    {
        #region Private Fields
        private Guid _accountID;
        private long _accountCode;
        private DateTime _accountDate;
        private double _balance;
        private Customer _customerAccount;
        private DateTime _today;
        #endregion

        #region Properties
        /// <summary>
        /// Guid of account for unique identification
        /// </summary>
        public Guid AccountID { get => _accountID; set => _accountID = value; }
        /// <summary>
        /// Auto-generated code number of account
        /// </summary>
        public long AccountCode
        {
            get => _accountCode;
            set
            {
                if (value > 0)
                {
                    _accountCode = value;
                }
                else
                {
                    throw new AccountException("Account code should be positive only.");
                }
            }
        }
        /// <summary>
        /// Creating date of Account
        /// </summary>
        public DateTime AccountDate { get => _accountDate; set => _accountDate = value; }
        /// <summary>
        /// Account balance
        /// </summary>
        public double Balance 
        { get => _balance;
            set
            {
                if (value >= 0)
                {
                    _balance = value;
                }
                else
                {
                    throw new AccountException("Amount should be positive number only.");
                }
            }
        }/// <summary>
        /// Account Holder (Customer object)
        /// </summary>
        public Customer CustomerAccount { get => _customerAccount; set => _customerAccount = value; }
        /// <summary>
        /// Today DateTime object
        /// </summary>
        public DateTime Today { get => _today; set => _today = value; }

        /// <summary>
        /// Method that creates a copy of Account
        /// </summary>
        /// <returns></returns>
        #endregion

        #region Methods
        public object Clone()
        {
            return new Account() { AccountID = this.AccountID, AccountCode = this.AccountCode, AccountDate = this.AccountDate, Balance = this.Balance, CustomerAccount = this.CustomerAccount, Today = this.Today };
        }
        #endregion

    }

}
