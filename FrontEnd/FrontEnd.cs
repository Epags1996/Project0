//Beutified using https://codebeautify.org/csharpviewer
using BusinessLayer;
using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd
{
    public class FrontEnd
    {
        //fucntions through out the code
        public static bool customerIDValid(int customerID) //used to validate a customer's ID making sure they actually have an account
        {
            bool valid = false;

            foreach (Customer item in BankDAL.CusList)
            {
                if (item.CustomerID == customerID)
                {
                    valid = true;
                }
            }

            return valid;
        }

        public static bool accountIDValid(int accountID)//used to validate if customer acctually has bank account
        {
            bool valid = false;

            foreach (Account item in BankDAL.AccList)
            {
                if (item.accountID == accountID)
                {
                    valid = true;
                }
            }

            return valid;
        }

        public static void incorrectKey()//if customer hits wrong key, resets menu
        {
            Console.WriteLine("You have pressed an incorrect key");
            Console.WriteLine("Press <Enter> to return to the start menu");
            FrontEnd.frontEnd();
        }

        public static void main() //restarts ui
        {
            Console.WriteLine("Press <Enter> to return to the start menu");
            Console.ReadLine();
            FrontEnd.frontEnd();
        }

        public static int getCustomerID() //Used to get inputed customer id and uses customerIDValid to check if it is a created ID
        {
            try
            {
                int custId = Convert.ToInt32(Console.ReadLine());
                if (!customerIDValid(custId))
                {
                    Console.WriteLine("This customer account does not exist.");
                    main();
                }
                return custId;
            }
            catch
            {
                Console.WriteLine("Invalid Customer ID");
                FrontEnd.frontEnd();
                return 0;
            }
        }

        public static int getAccountID() //Used to get inputed account id and uses accountIDValid to check if it is a created account ID
        {
            try
            {
                int accountId = Convert.ToInt32(Console.ReadLine());
                if (!accountIDValid(accountId))
                {
                    Console.WriteLine("This banking account does not exist.");
                    Console.WriteLine("Please press enter to return to the main menu");
                    Console.ReadLine();
                    FrontEnd.frontEnd();
                }
                return accountId;
            }
            catch
            {
                incorrectKey();
                return 0;
            }
        }

        public static double getWithdrawDepositTransfer()//when a customer makes a withdraw, deposit or transfer this function gets that ammount
        {

            try
            {
                double withdrawDepositTransfer = Convert.ToInt32(Console.ReadLine());

                return withdrawDepositTransfer;
            }
            catch
            {
                incorrectKey();
                return 0;
            }
        }
        public static void frontEnd()//front end that the customer sees
        {
            //Starting Menu, used to register a new customer, create banking accounts, do a transaction, and view accounts
            Console.Clear();
            Console.WriteLine("Welcome to Eric Pagliari's work in progress.");
            Console.WriteLine("If you find a bug, it's called a feature.\n");
            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("1. Register\n");
            Console.WriteLine("2. Create Account\n");
            Console.WriteLine("3. Transaction\n");
            Console.WriteLine("4. View Accounts\n");
            string response = Console.ReadLine();

            switch (response)
            {
                //user inputs 1, switch case creates and account
                case "1":
                    Console.Clear();
                    CustomerBL customerBL = new CustomerBL();
                    customerBL.CreateCustomer();
                    Console.WriteLine("Press <Enter> to return to the start menu");
                    Console.ReadLine();
                    frontEnd();
                    break;
                //user inputs 2, asks for a customer id, if a correct customer id is added a second menu is shown that
                //allows them to choose what account to make
                case "2":
                    Console.Clear();
                    Console.WriteLine("What's your customer id");
                    int customerID = getCustomerID();

                    //List of 4 accounts a customer can make
                    Console.WriteLine("What type of account would you like\n");
                    Console.WriteLine("1. Business Account\n");
                    Console.WriteLine("2. Checking Account\n");
                    Console.WriteLine("3. Loan Account\n");
                    Console.WriteLine("4. Term Account\n");
                    string accType = Console.ReadLine();
                    double intrest = 0.00;
                    double bal = 0;
                    //Customer selects 1, creates business account
                    if (accType == "1")
                    {
                        accType = "Business Account";
                        intrest = 0.5;
                        Account newAcc = new BusinessAccount()
                        {
                            accountType = accType,
                            accountID = BankDAL.accountID,
                            customerID = customerID,
                            accountInterestRate = intrest,
                            accountBalance = bal
                        };
                        BankDAL.accountID++;

                        AccountBL accountBL = new AccountBL();
                        Console.WriteLine(accountBL.Create(newAcc));
                    }
                    //Customer selects 2, creates checking account
                    else if (accType == "2")
                    {
                        accType = "Checking Account";
                        intrest = 0.25;
                        Account newAcc = new CheckingAccount()
                        {
                            accountType = accType,
                            accountID = BankDAL.accountID,
                            customerID = customerID,
                            accountInterestRate = intrest,
                            accountBalance = bal
                        };
                        BankDAL.accountID++;

                        AccountBL accountBL = new AccountBL();
                        Console.WriteLine(accountBL.Create(newAcc));
                    }
                    //Customer selects 3, creates Loan account
                    else if (accType == "3")
                    {
                        accType = "Loan Account";
                        intrest = 25.0;
                        Console.WriteLine("How much are you taking out on this loan?");
                        bal = 0 - Convert.ToInt32(Console.ReadLine());

                        Account newAcc = new LoanAccount()
                        {
                            accountType = accType,
                            accountID = BankDAL.accountID,
                            customerID = customerID,
                            accountInterestRate = intrest,
                            accountBalance = bal
                        };
                        BankDAL.accountID++;

                        AccountBL accountBL = new AccountBL();
                        Console.WriteLine(accountBL.Create(newAcc));

                    }
                    //Customer selects 4, creates Term account
                    else if (accType == "4")
                    {
                        accType = "Term Account";
                        intrest = 2.8;
                        Console.WriteLine("How much are you depositing in this account?");
                        bal = Convert.ToInt32(Console.ReadLine());
                        Account newAcc = new LoanAccount()
                        {
                            accountType = accType,
                            accountID = BankDAL.accountID,
                            customerID = customerID,
                            accountInterestRate = intrest,
                            accountBalance = bal
                        };
                        BankDAL.accountID++;

                        AccountBL accountBL = new AccountBL();
                        Console.WriteLine(accountBL.Create(newAcc));

                    }
                    else
                    {
                        //Customer doesnt select from the menu options, returns customer to start screen
                        incorrectKey();
                        FrontEnd.frontEnd();
                    }
                    Console.WriteLine("Press <Enter> to return to the start menu");
                    Console.ReadLine();
                    FrontEnd.frontEnd();
                    break;
                //Customer selects 3, if inputs valid account id and customer id and another menu is shown
                case "3":
                    Console.Clear();
                    Console.WriteLine("What's your account ID");
                    int accountId = getAccountID();

                    int Index = BankDAL.AccList.FindIndex(a => a.accountID.Equals(accountId));

                    Console.WriteLine("What's your customer id");
                    int ID = getCustomerID();
                    if (ID != BankDAL.AccList[Index].customerID)
                    {
                        Console.WriteLine($"Incorrect customer id for this account: {accountId}");
                        main();
                    }
                    //Menu with list of things a customer can do with once they open up there account
                    Console.Clear();
                    Console.WriteLine("What would you like to do with your account?\n");
                    Console.WriteLine("1. Check Balance\n");
                    Console.WriteLine("2. Deposit\n");
                    Console.WriteLine("3. Withdraw\n");
                    Console.WriteLine("4. Transfer\n");
                    Console.WriteLine("5. View Transactions\n");
                    Console.WriteLine("6. Remove account\n");
                    string transactionsType = Console.ReadLine();

                    //Shows customer account balance
                    if (transactionsType == "1")
                    {
                        Console.Clear();
                        var Bal = BankDAL.AccList[Index].accountBalance;
                        Console.WriteLine($"Your account balance is: ${Bal}");
                        Console.WriteLine("Press <Enter> to return to the start menu");
                        Console.ReadLine();
                        FrontEnd.frontEnd();
                    }
                    //allows customer to deposit money
                    else if (transactionsType == "2")
                    {
                        Console.Clear();
                        Console.WriteLine("How you putting in?");
                        var accountType = BankDAL.AccList[Index].accountType;
                        double deposit = getWithdrawDepositTransfer();
                        if (accountType == "Business Account")
                        {
                            BusinessAccount newAcc = new BusinessAccount();
                            newAcc = (BusinessAccount)BankDAL.AccList[Index];
                            Console.WriteLine(newAcc.deposit(deposit));
                            main();
                        }
                        else if (accountType == "Checking Account")
                        {
                            CheckingAccount newAcc = new CheckingAccount();
                            newAcc = (CheckingAccount)BankDAL.AccList[Index];
                            Console.WriteLine(newAcc.deposit(deposit));
                            main();
                        }
                        else if (accountType == "Loan Account")
                        {
                            LoanAccount newAcc = new LoanAccount();
                            newAcc = (LoanAccount)BankDAL.AccList[Index];
                            Console.WriteLine(newAcc.deposit(deposit));
                            main();
                        }
                        else if (accountType == "Term Account")
                        {
                            TermAccount newAcc = new TermAccount();
                            newAcc = (TermAccount)BankDAL.AccList[Index];
                            Console.WriteLine(newAcc.deposit(deposit));
                            main();
                        }
                    }
                    //allows customer to withdraw
                    else if (transactionsType == "3")
                    {
                        Console.Clear();
                        Console.WriteLine("How much are you taking out?");
                        double withdraw = getWithdrawDepositTransfer();

                        var accountType = BankDAL.AccList[Index].accountType;
                        if (accountType == "Business Account")
                        {
                            BusinessAccount newAcc = new BusinessAccount();
                            newAcc = (BusinessAccount)BankDAL.AccList[Index];
                            Console.WriteLine(newAcc.withdrawal(withdraw));
                            main();
                        }
                        else if (accountType == "Checking Account")
                        {
                            CheckingAccount newAcc = new CheckingAccount();
                            newAcc = (CheckingAccount)BankDAL.AccList[Index];
                            Console.WriteLine(newAcc.withdrawal(withdraw));
                            main();
                        }
                        else if (accountType == "Loan Account")
                        {
                            LoanAccount newAcc = new LoanAccount();
                            newAcc = (LoanAccount)BankDAL.AccList[Index];
                            Console.WriteLine(newAcc.withdrawal(withdraw));
                            main();
                        }
                        else if (accountType == "Term Account")
                        {
                            TermAccount newAcc = new TermAccount();
                            newAcc = (TermAccount)BankDAL.AccList[Index];
                            Console.WriteLine(newAcc.withdrawal(withdraw));
                            main();
                        }
                    }
                    //allows customer to tranfer money
                    else if (transactionsType == "4")
                    {
                        Console.Clear();
                        Console.WriteLine("Which account are you transfering money to");
                        int toAcc = getAccountID();
                        if (!accountIDValid(toAcc))
                        {
                            Console.WriteLine("That account doesn't exist");
                            Console.WriteLine("Press <Enter> to return to the menu");
                            Console.ReadLine();
                            FrontEnd.frontEnd();
                        }
                        int toAccIndex = BankDAL.AccList.FindIndex(a => a.accountID.Equals(toAcc));

                        if (ID != BankDAL.AccList[toAccIndex].customerID)
                        {
                            Console.WriteLine($"That account is not your account.");
                            main();
                        }

                        var toAccType = BankDAL.AccList[toAcc].accountType;

                        var accountType = BankDAL.AccList[Index].accountType;

                        Console.WriteLine("How much would you like to transfer?");
                        double transfer = getWithdrawDepositTransfer();
                        //transfer from business account
                        if (accountType == "Business Account")
                        {
                            BusinessAccount toNewAcc = new BusinessAccount();
                            toNewAcc = (BusinessAccount)BankDAL.AccList[toAccIndex];
                            Console.WriteLine(toNewAcc.deposit(transfer));

                            if (toAccType == "Business Account")
                            {
                                BusinessAccount toNewAcc2 = new BusinessAccount();
                                toNewAcc2 = (BusinessAccount)BankDAL.AccList[toAccIndex];
                                Console.WriteLine(toNewAcc2.deposit(transfer));
                                Console.WriteLine("Press <Enter> to return to the start menu");
                                Console.ReadLine();
                                FrontEnd.frontEnd();
                            }
                            else if (toAccType == "Checking Account")
                            {
                                CheckingAccount newAcc = new CheckingAccount();
                                newAcc = (CheckingAccount)BankDAL.AccList[Index];
                                Console.WriteLine(newAcc.withdrawal(transfer));
                                Console.WriteLine("Press <Enter> to return to the start menu");
                                Console.ReadLine();
                                FrontEnd.frontEnd();
                            }
                            else
                            {
                                Console.WriteLine("You can only transfer between checking and business");
                                Console.WriteLine("Press <Enter> to return to the start menu");
                                Console.ReadLine();
                                FrontEnd.frontEnd();
                            }
                        }
                        //transfer from checking account
                        else if (accountType == "Checking Account")
                        {
                            CheckingAccount newAcc = new CheckingAccount();
                            newAcc = (CheckingAccount)BankDAL.AccList[Index];
                            Console.WriteLine(newAcc.withdrawal(transfer));

                            if (toAccType == "Checking Account")
                            {
                                CheckingAccount toNewAcc = new CheckingAccount();
                                toNewAcc = (CheckingAccount)BankDAL.AccList[Index];
                                Console.WriteLine(toNewAcc.withdrawal(transfer));
                                Console.WriteLine("Press <Enter> to return to the start menu");
                                Console.ReadLine();
                                FrontEnd.frontEnd();
                            }
                            else if (toAccType == "Business Account")
                            {
                                BusinessAccount toNewAcc = new BusinessAccount();
                                toNewAcc = (BusinessAccount)BankDAL.AccList[toAccIndex];
                                Console.WriteLine(toNewAcc.deposit(transfer));
                                Console.WriteLine("Press <Enter> to return to the start menu");
                                Console.ReadLine();
                                FrontEnd.frontEnd();
                            }
                            else
                            {
                                Console.WriteLine("You can only transfer between checking and business");
                                Console.WriteLine("Press <Enter> to return to the start menu");
                                Console.ReadLine();
                                FrontEnd.frontEnd();
                            }

                        }
                        else
                        {
                            Console.WriteLine("You can only transfer between checking and business");
                            Console.WriteLine("Press <Enter> to return to the start menu");
                            Console.ReadLine();
                            FrontEnd.frontEnd();
                        }

                    }
                    //allows customer to view all transactions of an account
                    else if (transactionsType == "5")
                    {
                        Console.Clear();
                        var AccountType = BankDAL.AccList[Index].accountType;

                        if (AccountType == "Business Account")
                        {
                            BusinessAccount newAcc = new BusinessAccount();
                            newAcc = (BusinessAccount)BankDAL.AccList[Index];
                            foreach (Transactions item in newAcc.get())
                            {
                                Console.WriteLine(item.customerMessage);
                            }
                            main();


                        }
                        else if (AccountType == "Checking Account")
                        {
                            CheckingAccount newAcc = new CheckingAccount();
                            newAcc = (CheckingAccount)BankDAL.AccList[Index];
                            foreach (Transactions item in newAcc.get())
                            {
                                Console.WriteLine(item.customerMessage);
                            }
                            main();

                        }
                        else if (AccountType == "Loan Account")
                        {
                            LoanAccount newAcc = new LoanAccount();
                            newAcc = (LoanAccount)BankDAL.AccList[Index];
                            foreach (Transactions item in newAcc.get())
                            {
                                Console.WriteLine(item.customerMessage);
                            }
                            main();
                        }
                        else if (AccountType == "Term Account")
                        {
                            TermAccount newAcc = new TermAccount();
                            newAcc = (TermAccount)BankDAL.AccList[Index];
                            foreach (Transactions item in newAcc.get())
                            {
                                Console.WriteLine(item.customerMessage);
                            }
                            main();

                        }


                    }
                    //allows user to delete bank account
                    else if (transactionsType == "6")
                    {
                        Console.Clear();
                        BankDAL.AccList.RemoveAt(Index);
                        Console.WriteLine($"You removed your account");
                        Console.WriteLine("Press <Enter> to return to the start menu");
                        Console.ReadLine();
                        FrontEnd.frontEnd();

                    }
                    else
                    {
                        incorrectKey();
                    }

                    break;
                case "4":
                    //customer selects 4, allows customer to view all transactions under a cetrain account
                    Console.Clear();
                    Console.WriteLine("Please enter your customer ID");
                    int customerId = getCustomerID();
                    if (!customerIDValid(customerId))
                    {
                        Console.WriteLine("There is no customer under that number.");
                        main();
                    }
                    else
                    {
                        Console.WriteLine("The customer Id you provided is associated with the following accounts...");
                        foreach (Account item in BankDAL.AccList)
                        {
                            if (item.customerID == customerId)
                            {
                                Console.WriteLine($"{item.accountType}\n Balance: {item.accountBalance} dollars\n account ID {item.accountID}");
                            }
                        }
                        main();
                    }


                    break;
                default:
                    incorrectKey();
                    break;
            }
        }
    }
}