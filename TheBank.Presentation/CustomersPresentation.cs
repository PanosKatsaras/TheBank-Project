using System;
using System.Collections.Generic;
using TheBank.Entities;
using TheBank.Exceptions;
using TheBank.BusinessLogicLayer;
using TheBank.BusinessLogicLayer.BALContracts;
using TheBank.Entities.Contracts;

namespace TheBank.Presentation
{
    static class CustomersPresentation
    {
        /// <summary>
        /// Method that adds a customer
        /// </summary>
        internal static void AddCustomer()
        {
            try
            {
                //create an object of customer
                Customer customer = new Customer();

                //read all the details from user
                Console.WriteLine("\n*****ADD CUSTOMER*****");
                Console.Write("Customer Full Name:");
                customer.CustomerFullName = Console.ReadLine();
                Console.Write("Address:");
                customer.CustomerAdress = Console.ReadLine();
                Console.Write("City:");
                customer.CustomerCity = Console.ReadLine();
                Console.Write("Country:");
                customer.CustomerCountry = Console.ReadLine();
                Console.Write("Mobile number:");
                customer.CustomerMobile = Console.ReadLine();
                Console.Write("Email:");
                customer.CustomerEmail = Console.ReadLine();


                //Create BusinessLogic object
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();
                //Create a Guid
                Guid newGuid = customersBusinessLogicLayer.AddCustomer(customer);
                //Get customers by condition
                List<Customer> matchingCustomers = customersBusinessLogicLayer.GetCustomersByCondition(item => 
                item.CustomerID == newGuid);
                //Print customer code
                if(matchingCustomers.Count >= 1)
                {
                    Console.WriteLine("Customer Code: " + matchingCustomers[0].CustomerCode);
                    Console.WriteLine("Customer added.\n");
                }
                else
                {
                    Console.WriteLine("Customer not added!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }
        /// <summary>
        /// Method that updates customer
        /// </summary>
        internal static void UpdateCustomer()
        {
            try
            {
                Console.WriteLine("\n*****UPDATE CUSTOMER*****");
                Console.Write("Enter code of customer:");
                long code = long.Parse(Console.ReadLine());
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();
                List<Customer> matchingCustomer = customersBusinessLogicLayer.GetCustomersByCondition(item => item.CustomerCode == code);
                matchingCustomer[0].CustomerCode = code;

                Console.Write("Customer Full Name:");
                matchingCustomer[0].CustomerFullName = Console.ReadLine();
                Console.Write("Address:");
                matchingCustomer[0].CustomerAdress = Console.ReadLine();
                Console.Write("City:");
                matchingCustomer[0].CustomerCity = Console.ReadLine();
                Console.Write("Country:");
                matchingCustomer[0].CustomerCountry = Console.ReadLine();
                Console.Write("Mobile number:");
                matchingCustomer[0].CustomerMobile = Console.ReadLine();
                Console.Write("Email:");
                matchingCustomer[0].CustomerEmail = Console.ReadLine();

                bool updateCustomer = customersBusinessLogicLayer.UpdateCustomer(matchingCustomer[0]);

                if (updateCustomer==true)
                {
                    Console.WriteLine("New Customer Code: " + matchingCustomer[0].CustomerCode);
                    Console.WriteLine("New Customer Name: " + matchingCustomer[0].CustomerFullName);
                    Console.WriteLine("Customer updated.\n");
                }
                else
                {
                    Console.WriteLine("Customer not updated!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        /// <summary>
        /// Method that deletes customer
        /// </summary>
        internal static void DeleteCustomer()
        {
            try
            {
                Console.WriteLine("\n*****DELETE CUSTOMER*****");
                Console.Write("Enter code of customer:");
                long code = long.Parse(Console.ReadLine());
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();
                List<Customer> matchingCustomer = customersBusinessLogicLayer.GetCustomersByCondition(item => item.CustomerCode == code);
                bool deleteCustomer = customersBusinessLogicLayer.DeleteCustomer(matchingCustomer[0].CustomerID);

                if (deleteCustomer == true)
                {
                    Console.WriteLine("\nCustomer deleted.");
                }
                else
                {
                    Console.WriteLine("Customer not deleted!");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        /// <summary>
        /// Method that views customers
        /// </summary>
        internal static void ViewCustomers()
        {
            try
            {
                Console.WriteLine("\n*****VIEW CUSTOMERS*****");
                Console.WriteLine();
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();
                List<Customer> viewCustomers = customersBusinessLogicLayer.GetCustomers();
                
                if (viewCustomers != null)
                {
                    foreach (Customer customer in viewCustomers)
                    {
                        Console.Write("Customer code: " + customer.CustomerCode + ", ");
                        Console.Write("Full Name: " + customer.CustomerFullName + ", ");
                        Console.Write("Adress: " + customer.CustomerAdress + ", ");
                        Console.Write("City: " + customer.CustomerCity + ", ");
                        Console.Write("Country: " + customer.CustomerCountry + ", ");
                        Console.Write("Mobile: " + customer.CustomerMobile + ", ");
                        Console.Write("Email: " + customer.CustomerEmail);
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }
    }
}
