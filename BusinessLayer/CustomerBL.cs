using Entities;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CustomerBL
    {
        public string Create(Customer newCustomer)
        {
            CustomerDAL customerDAL = new CustomerDAL();
            return customerDAL.Create(newCustomer);
        }

        public void CreateCustomer()
        {
            Console.WriteLine("what is your first name");
            string firstName = Console.ReadLine();
            Console.WriteLine("What is your last name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Create a password");
            string password = Console.ReadLine();


            Customer customer = new Customer()
            {
                CustomerID = BankDAL.customerID,
                FirstName = firstName,
                LastName = lastName,
                Password = password

            };
            BankDAL.customerID++;
            CustomerBL customerBL = new CustomerBL();
            Console.WriteLine(customerBL.Create(customer));
        }

    }
}
