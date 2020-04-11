using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch5_Greet
{
    class ProgramUI
    {
        private CustomerRepo _customerRepo = new CustomerRepo();

        public void Run()
        {
            Menu();
        }

        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("What do you want to do\n" +
                    "1: Create a new customer\n" +
                    "2: Show list of customers\n" +
                    "3: Update a customer's info\n" +
                    "4: Delete a customer\n" +
                    "5: Exit");

                string response = Console.ReadLine();

                switch (response)
                {
                    case "1":
                        CreateNewCustomer();
                        break;
                    case "2":
                        DisplayCustomerList();
                        break;
                    case "3":
                        UpdateExistingCustomer();
                        break;
                    case "4":
                        DeleteCustomer();
                        break;
                    case "5":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateNewCustomer()
        {
            Customer customer = new Customer();
            Console.Clear();

            Console.WriteLine("Enter the customer number:");
            customer.CustomerNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the first name of the customer:");
            customer.FirstName = Console.ReadLine();

            Console.WriteLine("Enter the last name of the customer:");
            customer.LastName = Console.ReadLine();

            Console.WriteLine("Enter the type of customer(past, current, or potential):");
            customer.CustomerType = Console.ReadLine().ToLower();

            bool isEmailSet = false;
            while (!isEmailSet)
            {
                if (customer.CustomerType == "past")
                {
                    customer.Email = "It's been a long time since we've heard from you. we want you back.";
                    isEmailSet = true;
                }
                else if (customer.CustomerType == "current")
                {
                    customer.Email = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                    isEmailSet = true;
                }
                else if (customer.CustomerType == "potential")
                {
                    customer.Email = "We currently have the lowest rates on Helicopter Insurance!";
                    isEmailSet = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid option");
                }
            }

            Console.WriteLine($"The customer type is : {customer.CustomerType}");
            _customerRepo.AddNewCustomer(customer);
        }

        private void DisplayCustomerList()
        {
            Console.Clear();

            List<Customer> customers = _customerRepo.GetCustomers();

            foreach (Customer customer in customers)
            {
                Console.WriteLine($"Customer number is: {customer.CustomerNumber}\n" +
                    $"Customer's first name is: {customer.FirstName}\n" +
                    $"Customer's last name is: {customer.LastName}\n" +
                    $"Customer type is: {customer.CustomerType}\n" +
                    $"Email to send to customer is:\n{customer.Email}\n");
            }
        }

        private void UpdateExistingCustomer()
        {
            DisplayCustomerList();

            Console.WriteLine("Enter the number of the customer you want to update:");
            int oldCustomer = Convert.ToInt32(Console.ReadLine());

            Customer customer = new Customer();
            Console.Clear();

            Console.WriteLine("Enter the customer number:");
            customer.CustomerNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the first name of the customer:");
            customer.FirstName = Console.ReadLine();

            Console.WriteLine("Enter the last name of the customer:");
            customer.LastName = Console.ReadLine();

            Console.WriteLine("Enter the type of customer(past, current, or potential):");
            customer.CustomerType = Console.ReadLine().ToLower();

            bool isNewEmailSet = false;
            while (!isNewEmailSet)
            {
                if (customer.CustomerType == "past")
                {
                    customer.Email = "It's been a long time since we've heard from you. we want you back.";
                    isNewEmailSet = true;
                }
                else if (customer.CustomerType == "current")
                {
                    customer.Email = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                    isNewEmailSet = true;
                }
                else if (customer.CustomerType == "potential")
                {
                    customer.Email = "We currently have the lowest rates on Helicopter Insurance!";
                    isNewEmailSet = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid option");
                }
            }

            Console.WriteLine($"The customer type is : {customer.CustomerType}");

            bool wasUpdated = _customerRepo.UpdateExistingCustomer(oldCustomer, customer); 

            if (wasUpdated)
            {
                Console.WriteLine("Customer information was successfully updated.");
            }
            else
            {
                Console.WriteLine("Could not update customer information.");
            }
        }

        private void DeleteCustomer()
        {
            Console.Clear();

            DisplayCustomerList();

            Console.WriteLine("Enter the customer number of the customer you would like to delete.");
            int response = Convert.ToInt32(Console.ReadLine());
            bool wasDeleted = _customerRepo.DeleteCustomerFromRepo(response);

            if (wasDeleted)
            {
                Console.WriteLine("The customer was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The customer could not be deleted.");
            }
        }
    }
}
