namespace ApplicationTest.Data.Entities
{
    /// <summary>
    /// Entity account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Principal constructor
        /// </summary>
        /// <param name="initialBalance">Value for initial balance</param>
        public Account(decimal initialBalance)
        {
            Balance = initialBalance ;
        }
        public decimal Balance { get; set; }

        /// <summary>
        /// Method responsible to validate if the user can do a withdraw
        /// </summary>
        /// <param name="amount">Valie to withdraw</param>
        /// <returns>true if the user has a sufficient amount, false if not</returns>
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
