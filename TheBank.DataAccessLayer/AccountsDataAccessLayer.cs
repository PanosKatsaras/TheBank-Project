using System;
using System.Collections.Generic;
using TheBank.Entities;
using TheBank.Exceptions;
using TheBank.DataAccessLayer.DALContracts;

namespace TheBank.DataAccessLayer
{
    /// <summary>
    /// Class that represents data access layer for bank accounts
    /// </summary>
    public class AccountsDataAccessLayer:IAccountsDataAccessLayer
    {
        #region Fields
        private static List<Account> _accounts;
        private static double _sourceAmount;
        private static double _destinationAmount;
        #endregion

        #region Constructors
        static AccountsDataAccessLayer()
        {
            _accounts = new List<Account>();
        }
        #endregion

        #region Properties
        private static List<Account> Accounts
        {
            get => _accounts;
            set => _accounts = value;
        }
        public static double SourceAmount 
        { 
            get => _sourceAmount; 
            set => _sourceAmount = value; 
        }
        public static double DestinationAmount
        {
            get => _destinationAmount;
            set => _destinationAmount = value;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Method that returns all existing accounts
        /// </summary>
        /// <returns></returns>
        public List<Account> GetAccounts()
        {
            try
            {
                List<Account> accountsList = new List<Account>();
                
                Accounts.ForEach(item => accountsList.Add(item.Clone() as Account));
                return accountsList;
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
        
        /// <summary>
        /// Method that returns a set of accounts that matches with specified criteria 
        /// </summary>
        /// <param name="predicate">Lambda expression that contains condition to check</param>
        /// <returns>The list of matching accounts</returns>
        public List<Account> GetAccountsByCondition(Predicate<Account> predicate)
        {
            try
            {
                List<Account> accountsList = new List<Account>();

                List<Account> filteredAccountsList = Accounts.FindAll(predicate);
                filteredAccountsList.ForEach(item => accountsList.Add(item.Clone() as Account));
                return accountsList;
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
        /// <summary>
        /// Method that adds a new account to the existing list
        /// </summary>
        /// <param name="account">Account object to add</param>
        /// <returns>Returns Guid of new account</returns>
        public Guid NewAccount(Account account)
        {
            try
            {
                Accounts.Add(account);
                account.AccountID = Guid.NewGuid();
                return account.AccountID;
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
        /// <summary>
        /// Method that updates an existing account's details
        /// </summary>
        /// <param name="account">Account object with updated details</param>
        /// <returns>Determains whether the account is updated or not</returns>
        public bool UpdateAccount(Account account)
        {
            try
            {
                Account existingAccount = Accounts.Find(item => item.AccountID == account.AccountID);
                if (existingAccount != null)
                {
                    existingAccount.AccountCode = account.AccountCode;
                    existingAccount.AccountDate = account.AccountDate;
                    existingAccount.Balance = account.Balance;

                    return true;
                }
                else
                {
                    return false;
                }
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
        /// <summary>
        /// Method that deletes an existing account based on AccountID
        /// </summary>
        /// <param name="accountID">AccountID to delete</param>
        /// <returns>Determains whether the account is deleted or not</returns>
        public bool DeleteAccount(Guid accountID)
        {
            try
            {
                if (Accounts.RemoveAll(item => item.AccountID == accountID) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
        /// <summary>
        /// Method that transfers the amount from source account to destination account 
        /// </summary>
        /// <param name="account1">Source account</param>    
        /// <param name="account2">Destination account</param>
        /// <param name="amount">Amount to transfer</param>
        /// <returns>Destination account balance after transfer</returns>
        public double AmountTransfer(Account account1,Account account2,double amount)
        {
            try
            {
                CustomersDataAccessLayer customer = new CustomersDataAccessLayer();
                List<Customer> customers = customer.GetCustomers();
                Account sourceAcount = Accounts.Find(item => item.AccountID == account1.AccountID);
                Account destinationAccount = Accounts.Find(item => item.AccountID == account2.AccountID);
                DateTime dateTimeToday = DateTime.Now;
                sourceAcount.Today = dateTimeToday;
                destinationAccount.Today = dateTimeToday;
                if (sourceAcount != null && destinationAccount != null && amount < sourceAcount.Balance)
                {
                    Console.WriteLine("Date of transfer: " + dateTimeToday.ToString());
                    Console.WriteLine($"Amount of transfer:{amount}");
                    Console.WriteLine($"Account 1 (Source Account), Account Code:{sourceAcount.AccountCode}, Customer Code:{sourceAcount.CustomerAccount.CustomerCode}, Balance:{sourceAcount.Balance}" );
                    Console.WriteLine($"Account 2 (Destination Account), Account Code:{destinationAccount.AccountCode}, Customer Code:{destinationAccount.CustomerAccount.CustomerCode}, Balance:{destinationAccount.Balance}" );
                    SourceAmount = sourceAcount.Balance -= amount;
                    DestinationAmount = destinationAccount.Balance += amount;
                    foreach(Customer custom in customers)
                    {
                        if(custom.CustomerCode == sourceAcount.CustomerAccount.CustomerCode)
                        {
                            Console.WriteLine();
                            Console.Write("Source Account - Customer FullName: " + custom.CustomerFullName + ", ");
                        }
                    }
                    foreach (Customer custom in customers)
                    {
                        if (custom.CustomerCode == destinationAccount.CustomerAccount.CustomerCode)
                        {
                            
                            Console.Write("Destination Account - Customer FullName: " + custom.CustomerFullName);
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine($"Account 1 (Source Account), Account Code:{sourceAcount.AccountCode}, Customer Code:{sourceAcount.CustomerAccount.CustomerCode}, Current Balance:{SourceAmount}");
                    Console.WriteLine($"Account 2 (Destination Account), Account Code:{destinationAccount.AccountCode}, Customer Code:{destinationAccount.CustomerAccount.CustomerCode}, Current Balance:{DestinationAmount}");
                    return DestinationAmount; 
                }
                else
                {
                    Console.WriteLine("Invalid Input!");
                    return 0;
                }
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
        /// <summary>
        /// Method that returns the transferred funds
        /// </summary>
        /// <returns>A list of transferred funds</returns>
        public List<Account> GetFunds()
        {
            try
            {
                List<Account> fundsList = new List<Account>();
                List<Account> accountsList = GetAccounts();
                foreach (Account item in accountsList)
                {
                    if(item.Balance == SourceAmount || item.Balance == DestinationAmount)
                    {
                        fundsList.Add(item);
                    }
                }
                return fundsList;
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
        /// <summary>
        /// Method that returns transactions by date
        /// </summary>
        /// <param name="date">Date of transaction</param>
        /// <returns>A list of transactions by date</returns>
        public List<Account> GetTransactions(DateTime date)
        {
            try
            {
                List<Account> transactionsList = new List<Account>();
                List<Account> accountsList = GetAccounts();
            
                foreach (Account item in accountsList)
                {
                    if (item.Today.ToShortDateString() == date.ToShortDateString() && item.Balance == SourceAmount)
                    {
                       
                        transactionsList.Add(item);
                    }
                    else if (item.Today.ToShortDateString() == date.ToShortDateString() && item.Balance == DestinationAmount)
                    {
                       
                        transactionsList.Add(item);
                    }
                }
                return transactionsList;
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
