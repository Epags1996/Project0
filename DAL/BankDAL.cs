using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BankDAL
    {
        public static int customerID = 100;
        public static int accountID = 100;
        public static List<Customer> CusList = new List<Customer>();
        public static List<Account> AccList = new List<Account>();

        public enum AccountTypes
        {
            CheckingAccount,
            BuisnessAccount,
            TermAccount,
            LoanAccount
        };


    }
}