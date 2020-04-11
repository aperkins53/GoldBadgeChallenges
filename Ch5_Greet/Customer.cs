using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch5_Greet
{
    public class Customer
    {
        public int CustomerNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CustomerType { get; set; }
        public string Email { get; set; }


        public Customer() { }

        public Customer(int customerNumber, string firstName, string lastName, string customerType, string email)
        {
            CustomerNumber = customerNumber;
            FirstName = firstName;
            LastName = lastName;
            CustomerType = customerType;
            Email = email;
        }
    }
}
