using ApplicationTest.Data.Entities;
using System;

namespace ApplicationTeste.Service.Services
{
    /// <summary>
    /// Class responsible to work with account 
    /// </summary>
    public class AccountService
    {
        #region Singleton
        /// <summary>
        /// Singleton implementation
        /// </summary>
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
        #endregion

        #region PublicMethods
        /// <summary>
        /// Method responsible to do a cash deposit
        /// </summary>
        /// <param name="value">Value to deposit</param>
        /// <param name="user">User for deposit</param>
        public void DepositCash(decimal value, User user)
        {

            if (ValidateUser(user))
            {
                user.Account.Balance += value;
                UserService.Instance.Save();
                LogService.Instance.SaveLog(typeof(AccountService), $"User: {user.Name} deposit cash value: {value} at: {DateTime.Now.ToLongTimeString()}");
            }
            else
            {
                LogService.Instance.SaveLog(typeof(AccountService), $"User: {user.Name} is not valid when try deposit cash at: {DateTime.Now.ToLongTimeString()}");
            }
        }

        /// <summary>
        /// Method responsible to do a withdraw
        /// </summary>
        /// <param name="value">Value to withdraw</param>
        /// <param name="user">User to widhdraw</param>
        /// <returns>a message telling what happened</returns>
        public string WithdrawCash(decimal value, User user)
        {
            if (ValidateUser(user))
            {
                if (user.Account.CanWitdraw(value))
                {
                    user.Account.Balance -= value;
                    UserService.Instance.Save();
                    LogService.Instance.SaveLog(typeof(AccountService), $"User: {user.Name} withdraw value: {value} at: {DateTime.Now.ToLongTimeString()}");
                    return "Withdraw successfully\nPlease, take your money!";
                }
                LogService.Instance.SaveLog(typeof(AccountService), $"User: {user.Name} try withdraw value: {value} with insufficient balance at: {DateTime.Now.ToLongTimeString()}");
                return "Insufficient balance";

            }
            LogService.Instance.SaveLog(typeof(AccountService), $"User: {user.Name} is not valid when try deposit cash at: {DateTime.Now.ToLongTimeString()}");
            return "Invalid user";

        }

        /// <summary>
        /// Method responsible to get a current balance
        /// </summary>
        /// <param name="user">User to get a balance</param>
        /// <returns>A value of current balance</returns>
        public decimal GetBalance(User user)
        {

            if (ValidateUser(user))
            {
                return user.Account.Balance;
            }

            return 0;
        }

        #endregion

        #region PrivateMethods
        /// <summary>
        /// Method responsible to validate a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private bool ValidateUser(User user)
        {
            return user != null;
        }
        #endregion

    }
}
