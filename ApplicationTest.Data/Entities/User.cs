using Newtonsoft.Json;

namespace ApplicationTest.Data.Entities
{
    /// <summary>
    /// Entity User
    /// </summary>
    public class User
    {
        /// <summary>
        /// Principal constructor
        /// </summary>
        /// <param name="id">User id</param>
        /// <param name="userName">username</param>
        /// <param name="initialBalance">value for initial balance</param>
        public User(int id, string userName, decimal initialBalance)
        {
            Name = userName;
            Id = id;
            Account = new Account(initialBalance);
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public Account Account { get; set; }

        /// <summary>
        /// Method responsible for user validate
        /// </summary>
        /// <returns>true if user is valid, false if not</returns>
        public bool IsValid()
        {
            if ((Id >= 1 && Id <= 99999) && !string.IsNullOrEmpty(Name))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// ToString override
        /// </summary>
        /// <returns>A formatted user string</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
