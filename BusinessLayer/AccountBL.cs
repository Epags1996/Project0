using Entities;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AccountBL
    {
        public string Create(Account newAccount)
        {
            AccountDAL accountDAL = new AccountDAL();
            return accountDAL.Create(newAccount);

        }

        //public void CreateBankingAccount()
        //{

        //}

    //    public void viewTransactions()
    //    {
    //        FrontEnd frontEnd = new FrontEnd();
    //        Console.WriteLine("Please enter your customer ID");
    //        int customerId = frontEnd.getCustomerID();
    //        if (!customerIDValidation(customerId))
    //        {
    //            Console.WriteLine("There is no customer under that number.");
    //            main();
    //        }
    //        else
    //        {
    //            Console.WriteLine("The customer Id you provided is associated with the following accounts...");
    //            foreach (Account item in BankDAL.AccList)
    //            {
    //                if (item.customerID == customerId)
    //                {
    //                    Console.WriteLine($"{item.accountType}\n Balance: {item.accountBalance} dollars\n account ID {item.accountID}");
    //                }
    //            }
    //            main();
    //        }
    //    }

    //    public static void incorrectKey()
    //    {
    //        Console.WriteLine("You have pressed an incorrect key");
    //        Console.WriteLine("Press <Enter> to return to the start menu");
    //        FrontEnd.frontEnd();
    //    }

    //    public static void main()
    //    {
    //        Console.WriteLine("Press <Enter> to return to the start menu");
    //        Console.ReadLine();
    //        FrontEnd.frontEnd();
    //    }
    }
}
