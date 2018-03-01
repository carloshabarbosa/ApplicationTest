using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest.Data.Entities
{
    public class User
    {
        public User(int id, string userName, decimal initialBalance)
        {
            Name = userName;
            Id = id;
            Account = new Account(initialBalance);
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public Account Account { get; set; }

        public bool IsValid()
        {
            if ((Id >= 1 && Id <= 99999) && !string.IsNullOrEmpty(Name))
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
