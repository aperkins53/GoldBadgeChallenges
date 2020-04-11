using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch5_Greet
{
    public class CustomerRepo
    {
        private List<Customer> _customers = new List<Customer>();

        //create
        public void AddNewCustomer(Customer customer)
        {
            _customers.Add(customer);
        }

        //read
        public List<Customer> GetCustomers()
        {
            return _customers;
        }

        //update
        public bool UpdateExistingCustomer(int originalCustomer, Customer newCustomer)
        {
            Customer oldCustomer = GetCustomerByNumber(originalCustomer);

            if (oldCustomer != null)
            {
                oldCustomer.CustomerNumber = newCustomer.CustomerNumber;
                oldCustomer.FirstName = newCustomer.FirstName;
                oldCustomer.LastName = newCustomer.LastName;
                oldCustomer.CustomerType = newCustomer.CustomerType;
                oldCustomer.Email = newCustomer.Email;
                return true;
            }
            else
            {
                return false;
            } 
        }

        //delete
        public bool DeleteCustomerFromRepo(int customerNumber)
        {
            Customer customer = GetCustomerByNumber(customerNumber);

            if(customer == null)
            {
                return false;
            }

            int initialCount = _customers.Count;
            _customers.Remove(customer);

            if(initialCount > _customers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //helper
        public Customer GetCustomerByNumber(int customerNumber)
        {
            foreach (Customer customer in _customers)
            {
                if(customer.CustomerNumber == customerNumber)
                {
                    return customer;
                }
            }

            return null;
        }
    }
}
