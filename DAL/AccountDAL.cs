using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccountDAL
    {
        public string Create(Account account)
        {
            string accountInfo = $"You have created a {account.accountType} account, with the accountID being  { account.accountID} Your new account has a balance of {account.accountBalance} and your inerest rate is {account.accountInterestRate}";
            BankDAL.AccList.Add(account);
            return accountInfo;

        }
    }

}
