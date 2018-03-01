using ApplicationTest.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTeste.Service.Services
{
    public class AccountService
    {
        private static AccountService instance;
        public static AccountService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountService();
                }
                return instance;
            }
        }


        public void DepositCash(decimal value, User user)
        {

            if (ValidateUser(user))
            {
                user.Account.Balance += value;
                UserService.Instance.Save();
            }
            
        }

        public string WithdrawCash(decimal value, User user)
        {
            if (ValidateUser(user))
            {
                if (user.Account.CanWitdraw(value))
                {
                    user.Account.Balance-=value;
                    UserService.Instance.Save();
                    return "Withdraw successfully\nPlease, take your money!";
                }

                return "Insuficient balance";
                
            }
            return "Invalid user";

            
        }

        public decimal GetBalance(User user)
        {

            if (ValidateUser(user))
            {
                return user.Account.Balance;
            }

            return 0;
        }



        private bool ValidateUser(User user)
        {
            return user != null;
        }
        
    }
}
