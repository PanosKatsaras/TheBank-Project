using System;
using System.Collections.Generic;
using TheBank.Entities;
using TheBank.Exceptions;
using TheBank.BusinessLogicLayer;

namespace TheBank.Presentation
{   /// <summary>
    /// Class that represents a presentation for bank accounts
    /// </summary>
    static class AccountsPresentation
    {

        /// <summary>
        /// Method that creates new Account
        /// </summary>
        internal static void NewAccount()
        {
            try
            {
                Console.WriteLine("\n*****NEW ACCOUNT*****");
                Console.WriteLine();
                //Create objects
                AccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();
                CustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();
                Account account = new Account();
                List<Account> matchingAccounts = new List<Account>();
                List<Customer> customersAccount = new List<Customer>();
                int counter1 = 0;
                while (counter1 < 3)
                {
                    //Read all the details from user
                    Console.Write("Account Date (Year-Month-Day):");
                    string input = Console.ReadLine();
                    if (DateTime.TryParse(input, out DateTime date))
                    {
                        account.AccountDate = date;
                        break;
                    }
                    else
                    {   //3 times limit
                        Console.WriteLine("Invalid Input!");
                        counter1++;
                    }
                }
                int counter2= 0;
                while (counter2 < 3)
                {
                    Console.Write("Account Balance:");
                    string input = Console.ReadLine();
                    if (double.TryParse(input, out double balance))
                    {
                        account.Balance = balance;
                        break;
                    }
                    else
                    {   //3 times limit
                        Console.WriteLine("Invalid Input!");
                        counter2++;
                    }
                }
                int counter3 = 0;
                while (counter3 < 3)
                {
                    Console.Write("Customer Code:");
                    long code = long.Parse(Console.ReadLine());
                    Console.WriteLine();

                    customersAccount = customersBusinessLogicLayer.GetCustomersByCondition(item =>
                    item.CustomerCode == code);

                    if (code > 1000 && customersAccount[0].CustomerCode == code)
                    {
                        account.CustomerAccount = customersAccount[0];
                        Guid newGuid = accountsBusinessLogicLayer.NewAccount(account);
                        matchingAccounts = accountsBusinessLogicLayer.GetAccountsByCondition(item =>
                        item.AccountID == newGuid);
                        break;
                    }
                    else
                    {   //3 times limit
                        Console.WriteLine("Invalid Input!");
                        counter3++;
                    }
                }
                //Print the Account details
                if (matchingAccounts.Count >= 1)
                {
                    Console.WriteLine("NEW ACCOUNT'S DETAILS");
                    Console.WriteLine("New Account Code: " + matchingAccounts[0].AccountCode);
                    Console.WriteLine("Customer Code: " + customersAccount[0].CustomerCode);
                    Console.WriteLine("Customer Name: " + customersAccount[0].CustomerFullName);
                    Console.WriteLine("Account Date: " + matchingAccounts[0].AccountDate.ToShortDateString());
                    Console.WriteLine("Balance: " + matchingAccounts[0].Balance);
                    Console.WriteLine("Account added.\n");
                }
                else
                {
                    Console.WriteLine("Account not added!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }
        /// <summary>
        /// Method that updates the Account
        /// </summary>
        internal static void UpdateAccount()
        {
            try
            {
                Console.WriteLine("\n*****EDIT ACCOUNT*****");
                Console.WriteLine();
                //Create objects
                CustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();
                AccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();
                //Take codes from user
                Console.Write("Enter Account Code:");
                long code = long.Parse(Console.ReadLine());
                Label:
                Console.Write("Enter Customer Code:");
                long code2 = long.Parse(Console.ReadLine());
                //List of customers by condition
                List<Customer> customersAccount = customersBusinessLogicLayer.GetCustomersByCondition(item =>
                item.CustomerCode == code2);
                //List of accounts by condition
                List<Account> matchingAccount = accountsBusinessLogicLayer.GetAccountsByCondition(item => item.AccountCode == code);
                //Take new date and new amount from user
                if (customersAccount[0].CustomerCode == code2)
                {
                    matchingAccount[0].CustomerAccount = customersAccount[0];
                    Console.Write("Enter Account new Date:");
                    matchingAccount[0].AccountDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter New Amount:");
                    matchingAccount[0].Balance = double.Parse(Console.ReadLine());
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Invalid Input!");
                    goto Label;
                }

                bool editAccount = accountsBusinessLogicLayer.UpdateAccount(matchingAccount[0]);

                //Print the updated Account details
                if (editAccount == true)
                {
                    Console.WriteLine("ACCOUNT NEW DETAILS");
                    Console.WriteLine("Account Code: " + matchingAccount[0].AccountCode);
                    Console.WriteLine("Customer Code: " + customersAccount[0].CustomerCode);
                    Console.WriteLine("Customer Code: " + customersAccount[0].CustomerFullName);
                    Console.WriteLine("New Account Date: " + matchingAccount[0].AccountDate.ToShortDateString());
                    Console.WriteLine("New Amount: " + matchingAccount[0].Balance);
                    Console.WriteLine("Account edited.\n");
                }
                else
                {
                    Console.WriteLine("Account not edited!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }
        /// <summary>
        /// Method that deletes the Account
        /// </summary>
        internal static void DeleteAccount()
        {
            try
            {
                Console.WriteLine("\n*****DELETE ACCOUNT*****");
                Console.WriteLine();
                //Read Account code from user
                Console.Write("Enter Account Code:");
                long code = long.Parse(Console.ReadLine());
                AccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();
                List<Account> matchingAccount = accountsBusinessLogicLayer.GetAccountsByCondition(item => item.AccountCode == code);
                matchingAccount[0].AccountCode = code;
                bool deleteAccount = accountsBusinessLogicLayer.DeleteAccount(matchingAccount[0].AccountID);
                Console.WriteLine();
                //Delete Account if the condition is true
                if (deleteAccount == true)
                {
                    Console.WriteLine("\nAccount deleted.");
                }
                else
                {
                    Console.WriteLine("Account not deleted!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }
        /// <summary>
        /// Method that prints the details of all existing accounts
        /// </summary>
        internal static void ViewAccounts()
        {
            try
            {
                Console.WriteLine("\n*****VIEW ACCOUNTS*****");
                Console.WriteLine();
                //Create objects
                CustomersBusinessLogicLayer customersBusinessLogicLayer2 = new CustomersBusinessLogicLayer();
                AccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();
                //Get a list of existing accounts
                List<Account> viewAccounts = accountsBusinessLogicLayer.GetAccounts();
                List<Customer> customers = customersBusinessLogicLayer2.GetCustomers();
                //Print the details of all the accounts
                if (viewAccounts != null)
                {
                    foreach (Account account in viewAccounts)
                    {
                        Console.Write("Account Code: " + account.AccountCode + ", ");
                        Console.Write("Customer Code: " + account.CustomerAccount.CustomerCode + ", ");
                        Console.Write("Account Date: " + account.AccountDate.ToShortDateString() + ", ");
                        Console.Write("Current Balance: " + account.Balance + ", ");
                        foreach (Customer customer in customers)
                        {
                            if(customer.CustomerFullName == account.CustomerAccount.CustomerFullName)
                            {
                                Console.Write("Customer Name: " + customer.CustomerFullName);
                                Console.WriteLine();
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        /// <summary>
        /// Method that transfers an amount from source Account to destination Account
        /// </summary>
        public static void AmountTransfer()
        {
            try
            {
                Console.WriteLine("\n*****TRANSFER AMOUNT*****");
                Console.WriteLine();
                //Read the details from user
                Console.Write("Enter Account Code 1 (Source Account):");
                long code1 = long.Parse(Console.ReadLine());
                Console.Write("Enter Account Code 2 (Destination Account):");
                long code2 = long.Parse(Console.ReadLine());
                Console.Write("Enter the amount you want to transfer:");
                double amount = double.Parse(Console.ReadLine());
                Console.WriteLine();
                //Create object
                AccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();
                //Get accounts that match with specified criteria
                List<Account> matchingAccount1 = accountsBusinessLogicLayer.GetAccountsByCondition(item => item.AccountCode == code1);
                List<Account> matchingAccount2 = accountsBusinessLogicLayer.GetAccountsByCondition(item => item.AccountCode == code2);
                //Call method of AccountsBusinessLogicLayer
                double transferAmount = accountsBusinessLogicLayer.AmountTransfer(matchingAccount1[0], matchingAccount2[0],amount);
                //Print that the amount tranferred if the condition is true
                if (transferAmount > 0)
                {            
                    Console.WriteLine("Amount transferred.\n");
                }
                else
                {
                    Console.WriteLine("Amount not transferred!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }
        /// <summary>
        /// Method that prints the details of funds transfers
        /// </summary>
        internal static void  FundsStatement()
        {
            try
            {
                Console.WriteLine("\n*****FUNDS STATEMENT*****");
                Console.WriteLine();
                Console.WriteLine("Funds Transfers:");
                //Create object
                AccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();
                //Get a list of funds transfers
                List<Account> allFundsList = accountsBusinessLogicLayer.GetFunds();
                //Print the details of the funds
                foreach (Account account in allFundsList)
                {
                    Console.WriteLine($"Account Code: {account.AccountCode}, Account Date: {account.AccountDate.ToShortDateString()}, Current Balance:{account.Balance} ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }
        /// <summary>
        /// Method that prints the details of transactions by date (date input from user)
        /// </summary>
        internal static void AccountsStatement()
        {
            try
            {
                Console.WriteLine("\n*****ACCOUNTS STATEMENT*****");
                Console.WriteLine();
                //Create object
                AccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();
                //Get the date of transaction from user
                Console.Write("Enter date (Year-Month-Day):");
                string input = Console.ReadLine();
                //Date validation
                if (DateTime.TryParse(input, out DateTime date))
                {
                    String.Format("{0:dd/MM/yyyy}", date);
                }
                else
                {
                    Console.WriteLine("Invalid Input!");
                }
                //Print details of transactions
                List<Account> allTransactionsList = accountsBusinessLogicLayer.GetTransactions(date);
                Console.WriteLine("List of transactions by date:");

                foreach (Account account in allTransactionsList)
                {
                        Console.WriteLine($"Account Code: {account.AccountCode}, Transaction Date: {account.Today.ToShortDateString()}, Current Balance:{account.Balance}");
                }
                allTransactionsList.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }
    }
}
