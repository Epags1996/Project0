using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class LoanAccount : Account
    {
        public string accountType { get; set; }
        public int accountID { get; set; }
        public int customerID { get; set; }
        public double accountInterestRate { get; set; }
        public double accountBalance { get; set; }

        public List<Transactions> transList = new List<Transactions>();

        public void addTransactions(Transactions newTrans)
        {
            this.transList.Add(newTrans);
        }

        public string withdrawal(double withdraw)
        {

            return "Unfortunatly you cannot withdraw from a loan bank account";
        }

        public string deposit(double deposit)
        {

            if ((this.accountBalance + deposit) > 0)
            {
                return $"Unfortunatly you can't deposit more than the remaining balance of {this.accountBalance}";
            }
            this.accountBalance = this.accountBalance + deposit;
            Transactions newTrans = new Transactions()
            {
                customerMessage = $"You have added {deposit} dollars at {DateTime.Now}. Your new balance is: {this.accountBalance } dollars."
            };
            this.addTransactions(newTrans);


            return $"You have added{deposit} dollars from your account with the account number {this.accountID}. Your new  balance is: {this.accountBalance }dollars.";

        }

        public List<Transactions> get()
        {
            return this.transList;
        }

        public void Transactions(Transactions newTrans)
        {
            throw new NotImplementedException();
        }
    }
}