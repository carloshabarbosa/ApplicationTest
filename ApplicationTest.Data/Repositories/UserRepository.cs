using ApplicationTest.Data.Common;
using ApplicationTest.Data.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ApplicationTest.Data.Repositories
{
    /// <summary>
    /// Class responsible for persist the user
    /// </summary>
    public class UserRepository
    {
        #region Singleton
        /// <summary>
        /// Singleton implementation
        /// </summary>
        private static UserRepository instance;
        public static UserRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserRepository();
                }

                return instance;
            }
        }

        #endregion

        #region PublicMethods
        /// <summary>
        /// Method responsible for retrieve the users
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        {
            var path = GetUserDataFileName();
            if (!FileUtils.ValidateFile(path))
            {
                FileUtils.CreateFile(path);
            }

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                if (!string.IsNullOrEmpty(json))
                {
                    return JsonConvert.DeserializeObject<List<User>>(json);
                }
                return new List<User>();
            }
        }

        /// <summary>
        /// Method responsible for save all users
        /// </summary>
        /// <param name="users"></param>
        public void Save(List<User> users)
        {
            var path = GetUserDataFileName();
            FileUtils.ResetFile(path);

            using (var file = File.CreateText(path))
            {
                var jsonSerializer = new JsonSerializer();
                jsonSerializer.Formatting = Formatting.Indented;

                jsonSerializer.Serialize(file, users.OrderBy(e => e.Id));

                file.Flush();
                file.Close();
            }
        }

        #endregion

        #region PrivateMethods
        /// <summary>
        /// Method responsible to get a user file name
        /// </summary>
        /// <returns>The user filename</returns>
        private string GetUserDataFileName()
        {
            var path = FileUtils.GetDataPath();
            return $"{path}/user.json";
        }

        #endregion

    }
}
