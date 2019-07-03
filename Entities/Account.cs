using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface Account
    {
        string accountType { get; set; }
        int accountID { get; set; }
        int customerID { get; set; }
        double accountInterestRate { get; set; }
        double accountBalance { get; set; }

        void Transactions(Transactions newTrans);

        string withdrawal(double withdraw);

        string deposit(double deposit);

    }
}
