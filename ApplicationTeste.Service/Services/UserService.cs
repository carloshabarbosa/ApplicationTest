using ApplicationTest.Data.Entities;
using ApplicationTest.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTeste.Service.Services
{
    public class UserService
    {
        private static UserService instance;
        public static UserService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserService();
                }
                return instance;
            }
        }

        private List<User> Users;

        public UserService()
        {
            LoadUsers();
        }

        public User AuthenticateUser(string userName)
        {
            var userAuthenticated = Users.FirstOrDefault(u => u.Name == userName);

            if (userAuthenticated != null)
            {
                return userAuthenticated;
            }
            return null;
        }

        public void CreateUser(string userName, decimal initialBalance)
        {
            var lastUser = Users.OrderByDescending(u => u.Id).FirstOrDefault();
            var id = 1;
            if (lastUser != null)
            {
                id = lastUser.Id++;
            }

            var user = new User(id, userName, initialBalance);

            if (user.IsValid())
            {
                Users.Add(user);
                Save();
            }
        }

        public User GetUserById(int userId)
        {
            return Users.FirstOrDefault(u => u.Id == userId);
        }

        public void Save()
        {
            UserRepository.Instance.Save(Users);
        }

        public List<User> GetUsers()
        {
            return Users.OrderBy(u => u.Id).ToList();
        }
        private void LoadUsers()
        {
            if (Users == null)
            {
                Users = new List<User>();
            }
            
            Users.AddRange(UserRepository.Instance.GetUsers());
        }

        
    }
}
