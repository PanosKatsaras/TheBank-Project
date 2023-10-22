using System;
using TheBank.Entities;

namespace TheBank.Presentation
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("**********The Bank**********");
            Console.WriteLine(":::Login Page:::");
            //Background and letters colors in console
            if (Console.BackgroundColor == ConsoleColor.Black)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
            }
            
            //Declare variable for password
            string password = "";
            //Read Username from keyboard (manager)
            Console.WriteLine("Username:");
            string userName = Console.ReadLine();

            //Read password from keyboard only if userName is entered
            if (userName != "")
            {
                //read password from keyboard (system)
                Console.WriteLine("Password:");
                password = Console.ReadLine();
            }

            //Get in main menu only if username and password are correct
            if (userName == "manager" && password == "system")
            {
                int mainMenuChoice = -1;
                do
                {
                    Console.WriteLine("\n:::::Main Menu:::::");
                    Console.WriteLine("1.Customers");
                    Console.WriteLine("2.Accounts");
                    Console.WriteLine("3.Funds Transfer");
                    Console.WriteLine("4.Funds Transfer Statement");
                    Console.WriteLine("5.Account Statement");
                    Console.WriteLine("0.Exit");
                    
                    //Check if user input choice is correct
                    Console.Write("Enter choice:");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out int choice))
                    {
                        mainMenuChoice = choice;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid Input!");
                    }
                    
                    //Switch case method for menus
                    switch (mainMenuChoice)
                    {
                        case 1:
                            CustomersMenu();
                            break;
                        case 2:
                            AccountsMenu();
                            break;
                        case 3:
                            FundsTransferMenu();
                            break;
                        case 4:
                            FundsTransferStatementMenu();
                            break;
                        case 5:
                            AccountStatementMenu();
                            break;
                    }
                } while (mainMenuChoice != 0);
            }
            else
            {
                Console.WriteLine("Invalid Username or Password! ");
            }
            Console.WriteLine("Thanks for visiting!");
            Console.ReadKey();

            //Customers menu
            static void CustomersMenu()
            {
                int customerMenuChoice = -1;
                do
                {
                    Console.WriteLine("\n:::::Customers Menu:::::");
                    Console.WriteLine("1.Add Customer");
                    Console.WriteLine("2.Update Customer");
                    Console.WriteLine("3.Delete Customer");
                    Console.WriteLine("4.View Customers");
                    Console.WriteLine("0.Back to main menu");

                    Console.Write("Enter choice:");
                    customerMenuChoice = Convert.ToInt32(Console.ReadLine());

                    switch (customerMenuChoice)
                    {
                        case 1:
                            CustomersPresentation.AddCustomer();
                            break;
                        case 2:
                            CustomersPresentation.UpdateCustomer();
                            break;
                        case 3:
                            CustomersPresentation.DeleteCustomer();
                            break;
                        case 4:
                            CustomersPresentation.ViewCustomers();
                            break;
                    }
                } while (customerMenuChoice != 0);
            }

            //Accounts menu
            static void AccountsMenu()
            {
                int accountMenuChoice = -1;
                do
                {
                    Console.WriteLine("\n:::::Accounts Menu:::::");
                    Console.WriteLine("1.New Account");
                    Console.WriteLine("2.Update Account ");
                    Console.WriteLine("3.Delete Account");
                    Console.WriteLine("4.View Accounts");
                    Console.WriteLine("0.Back to main menu");

                    Console.Write("Enter choice:");
                    accountMenuChoice = Convert.ToInt32(Console.ReadLine());

                    switch (accountMenuChoice)
                    {
                        case 1:
                            AccountsPresentation.NewAccount();
                            break;
                        case 2:
                            AccountsPresentation.UpdateAccount();
                            break;
                        case 3:
                            AccountsPresentation.DeleteAccount();
                            break;
                        case 4:
                            AccountsPresentation.ViewAccounts();
                            break;
                    }
                } while (accountMenuChoice != 0);
            }

            //Funds transfer menu
            static void FundsTransferMenu()
            {
                int fundMenuChoice = -1;
                do
                {
                    Console.WriteLine("\n:::::Funds Transfer Menu:::::");
                    Console.WriteLine("1.Transfer ammount");
                    Console.WriteLine("0.Back to main menu");

                    Console.Write("Enter choice:");
                    fundMenuChoice = Convert.ToInt32(Console.ReadLine());

                    switch (fundMenuChoice)
                    {
                        case 1:
                            AccountsPresentation.AmountTransfer();
                            break;
                    }
                } while (fundMenuChoice != 0);
            }

            //Funds transfer statement menu
            static void FundsTransferStatementMenu()
            {
                int fundStatementMenuChoice = -1;
                do
                {
                    Console.WriteLine("\n:::::Funds Transfer Statement Menu:::::");
                    Console.WriteLine("1.View Fund Transfer");
                    Console.WriteLine("0.Back to main menu");

                    Console.Write("Enter choice:");
                    fundStatementMenuChoice = Convert.ToInt32(Console.ReadLine());

                    switch (fundStatementMenuChoice)
                    {
                        case 1:
                            AccountsPresentation.FundsStatement();
                            break;

                    }
                } while (fundStatementMenuChoice != 0);
            }

            //Accounts statement menu
            static void AccountStatementMenu()
            {
                int accountStatementMenuChoice = -1;
                do
                {
                    Console.WriteLine("\n:::::Accounts Statement Menu:::::");
                    Console.WriteLine("1.View list of Transactions");
                    Console.WriteLine("0.Back to main menu");

                    Console.Write("Enter choice:");
                    accountStatementMenuChoice = Convert.ToInt32(Console.ReadLine());

                    switch (accountStatementMenuChoice)
                    {
                        case 1:
                            AccountsPresentation.AccountsStatement();
                            break;
                    }
                } while (accountStatementMenuChoice != 0);
            }
        }
    }
}
