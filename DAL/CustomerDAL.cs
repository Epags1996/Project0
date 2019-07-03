using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerDAL
    {
        public string Create(Customer customer)
        {
            string CustomerConsoleLine = $"Welcome {customer.FirstName} {customer.LastName} to your accout .Your customer ID number is {customer.CustomerID} and your password is {customer.Password}";
            BankDAL.CusList.Add(customer);
            return CustomerConsoleLine;


        }

    }
}