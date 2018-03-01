using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest.Data.Entities
{
    public class Account
    {
        public Account(decimal initialBalance)
        {
            Balance = initialBalance ;
        }
        public decimal Balance { get; set; }

        public bool CanWitdraw(decimal amount)
        {
            if (amount > Balance)
            {
                return false;
            }

            return true;
        }
    }
}
