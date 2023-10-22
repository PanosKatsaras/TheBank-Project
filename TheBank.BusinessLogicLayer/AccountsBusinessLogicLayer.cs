using System;
using System.Collections.Generic;
using TheBank.DataAccessLayer;
using TheBank.Entities;
using TheBank.BusinessLogicLayer.BALContracts;
using TheBank.Exceptions;

namespace TheBank.BusinessLogicLayer
{
    /// <summary>
    /// Represents business access layer for bank accounts 
    /// </summary>
    public class AccountsBusinessLogicLayer:IAccountsBusinessLogicLayer

    {
        #region Fields
        private AccountsDataAccessLayer _accountsDataAccessLayer;
        #endregion

        #region Constructors
        public AccountsBusinessLogicLayer()
        {
            _accountsDataAccessLayer = new AccountsDataAccessLayer();
        }
        #endregion

        #region Properties
        private AccountsDataAccessLayer AccountsDataAccessLayer
        {
            set => _accountsDataAccessLayer = value;
            get => _accountsDataAccessLayer;
        }
        #endregion

        #region Methods
        public List<Account> GetAccounts()
        {
            try
            {
                return AccountsDataAccessLayer.GetAccounts();
            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Account> GetAccountsByCondition(Predicate<Account> predicate)
        {
            try
            {
                return AccountsDataAccessLayer.GetAccountsByCondition(predicate);
            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Guid NewAccount(Account account)
        {
            try
            {
                List<Account> allAccounts = AccountsDataAccessLayer.GetAccounts();
                long maxAccountCode = 0;
                foreach (var item in allAccounts)
                {
                    if (item.AccountCode > maxAccountCode)
                    {
                        maxAccountCode = item.AccountCode;
                    }
                }
                if (allAccounts.Count >= 1)
                {
                    account.AccountCode = maxAccountCode + 1;
                }
                else
                {
                    account.AccountCode = TheBank.Configuration.Settings.BaseAccountNo + 1;
                }

                return AccountsDataAccessLayer.NewAccount(account);
            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateAccount(Account account)
        {
            try
            {
                return AccountsDataAccessLayer.UpdateAccount(account);
            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteAccount(Guid accountID)
        {
            try
            {
                return AccountsDataAccessLayer.DeleteAccount(accountID);
            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public double AmountTransfer(Account account1, Account account2,double amount)
        {
            try
            {
                return AccountsDataAccessLayer.AmountTransfer(account1, account2,amount);
            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Account> GetFunds()
        {
            try
            {   
                return AccountsDataAccessLayer.GetFunds();
            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Account> GetTransactions(DateTime date)
        {
            try
            {
                
                return AccountsDataAccessLayer.GetTransactions(date);
            }
            catch (AccountException)
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
