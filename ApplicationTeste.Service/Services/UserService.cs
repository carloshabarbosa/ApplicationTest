using ApplicationTest.Data.Entities;
using ApplicationTest.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTeste.Service.Services
{
    /// <summary>
    /// Class responsible to work with user 
    /// </summary>
    public class UserService
    {
        #region Singleton
        /// <summary>
        /// Singleton implementation
        /// </summary>
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

        #endregion

        #region Properties
        private List<User> Users;
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public UserService()
        {
            LoadUsers();
        }
        #endregion

        #region PublicMethods
        /// <summary>
        /// Method responsible for authenticate an user
        /// </summary>
        /// <param name="userName">username that is trying authenticate</param>
        /// <returns>A valid user object</returns>
        public User AuthenticateUser(string userName)
        {
            var userAuthenticated = Users.FirstOrDefault(u => u.Name == userName);

            if (userAuthenticated != null)
            {
                LogService.Instance.SaveLog(typeof(UserService), $"User: {userName} logged at: {DateTime.Now.ToLongTimeString()}");
                return userAuthenticated;
            }
            else if (userName == "admin")
            {
                CreateUser(userName, 1000);

                return AuthenticateUser(userName);
            }
            else
            {
                LogService.Instance.SaveLog(typeof(UserService), $"User: {userName} incorrect login at: {DateTime.Now.ToLongTimeString()}");
                return null;

            }
            return null;
        }

        /// <summary>
        /// Method responsible for create an user
        /// </summary>
        /// <param name="userName">user name</param>
        /// <param name="initialBalance">initial balance value</param>
        public void CreateUser(string userName, decimal initialBalance)
        {
            try
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

                LogService.Instance.SaveLog(typeof(UserService), $"User: {userName} created at: {DateTime.Now.ToLongTimeString()}");
            }
            catch (Exception e)
            {
                LogService.Instance.SaveLog(typeof(UserService), $"Error to create user: {userName} created at: {DateTime.Now.ToLongTimeString()}");
            }

        }

        /// <summary>
        /// Method responsible to save all users
        /// </summary>
        public void Save()
        {
            UserRepository.Instance.Save(Users);
        }

        /// <summary>
        /// Method responsible to retrieve all users
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        {
            return Users.OrderBy(u => u.Id).ToList();
        }
        #endregion

        #region PrivateMethods
        /// <summary>
        /// Method responsible to load all users into a property
        /// </summary>
        private void LoadUsers()
        {
            if (Users == null)
            {
                Users = new List<User>();
            }

            Users.AddRange(UserRepository.Instance.GetUsers());
        }
        #endregion

    }
}
