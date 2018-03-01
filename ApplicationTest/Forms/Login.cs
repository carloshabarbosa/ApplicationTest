using ApplicationTeste.Service.Services;
using System;

namespace ApplicationTest.Forms
{
    /// <summary>
    /// Class responsible for build the login form
    /// </summary>
    public class Login : BaseForm
    {
        /// <summary>
        /// Implementation of the abstract class for the login form
        /// </summary>
        public override void BuildForm()
        {
            base.BuildForm();
            var showLoginForm = true;

            while (showLoginForm)
            {
                Console.WriteLine("Enter with a valid user: ");

                var userName = Console.ReadLine();

                Program.loggedUser = UserService.Instance.AuthenticateUser(userName);
                if (Program.loggedUser != null)
                {
                    showLoginForm = false;
                    new MainMenu().BuildForm();
                }
                else
                {
                    new InitialMenu().BuildForm();
                }
            }
        }
    }
}
