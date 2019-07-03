using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CheckingAccount : Account
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
            try
            {
                if (this.accountBalance > withdraw)
                {
                    this.accountBalance = this.accountBalance - withdraw;
                    Transactions newTrans = new Transactions()
                    {
                        customerMessage = $"You have taken out {withdraw} dollars at {DateTime.Now}. Your new balance is: {this.accountBalance } dollars."
                    };
                    this.addTransactions(newTrans);

                    return $"You have taken out{withdraw} dollars from your account with the account number {this.accountID}. Your new  balance is: {this.accountBalance }dollars.";
                }
                else
                {
                    return $"You can not withdrawl ${ withdraw} because you only have ${this.accountBalance} in you account.";
                }
            }
            catch
            {
                //this.accountBalance = this.accountBalance + withdraw;
                return "Insufficient Funds";
            }


        }

        public string deposit(double deposit)
        {

            this.accountBalance = this.accountBalance + deposit;
            Transactions newTrans = new Transactions()
            {
                customerMessage = $"You have added {deposit} dollars at {DateTime.Now}. Your new balance is: {this.accountBalance } dollars."
            };
            this.addTransactions(newTrans);


            return $"You have taken out{deposit} dollars from your account with the account number {this.accountID}. Your new  balance is: {this.accountBalance }dollars.";

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
