using ApplicationTest.Data.Common;
using ApplicationTest.Data.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest.Data.Repositories
{
    public class UserRepository
    {
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

        private string GetUserDataFileName()
        {
            var path = FileUtils.GetDataPath();
            return $"{path}/user.json";
        }

        
    }
}
