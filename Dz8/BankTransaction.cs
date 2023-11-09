using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz8
{
    class BankTransaction
    {
        readonly DateTime transactionTime;
        readonly double money;
        public BankTransaction(double money)
        {
            transactionTime = DateTime.Now;
            this.money = money;
        }
        public override string ToString()
        {
            if (money < 0)
            {
                return $"{transactionTime} - снятие {Math.Abs(money)}";
            }
            else
            {
                return $"{transactionTime} - пополнение {money}";
            }
        }
    }
}
