using ApplicationTeste.Service.Services;
using System;
using System.Linq;

namespace ApplicationTest.Forms
{
    /// <summary>
    /// Class responsible for build the form that lists all users
    /// </summary>
    public class AllUsers : BaseForm
    {
        /// <summary>
        /// Implementation of the abstract class for the all users list
        /// </summary>
        public override void BuildForm()
        {
            base.BuildForm();

            var users = UserService.Instance.GetUsers();
            Console.WriteLine("********All users**************\n");
            if (users.Any())
            {
                users.ForEach(e =>
                {
                    Console.WriteLine($"{e.ToString()}");
                });
            }
            Console.WriteLine("\n");

            FooterForm();
            new MainMenu().BuildForm();
        }
    }
}
