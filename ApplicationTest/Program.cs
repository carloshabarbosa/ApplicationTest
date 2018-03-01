using ApplicationTest.Data.Entities;
using ApplicationTest.Forms;
using ApplicationTeste.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest
{
    class Program
    {
        private static string applicationName = "ATM Application Test";
        public static User user;
        static void Main(string[] args)
        {
            new InitialMenu().BuildForm();

            Console.ReadKey();
        }

        private static void ShowLoginForm()
        {
            Console.Clear();
            try
            {
               
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                
            }
        }
    }
}
