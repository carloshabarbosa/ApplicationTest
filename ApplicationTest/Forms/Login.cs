using ApplicationTeste.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest.Forms
{
    public class Login : BaseForm
    {
        public override void BuildForm()
        {
            base.BuildForm();
            var showLoginForm = true;

            while (showLoginForm)
            {
                Console.WriteLine("ENTER WITH A VALID USER: ");

                var userName = Console.ReadLine();

                Program.user = UserService.Instance.AuthenticateUser(userName);
                if (Program.user != null)
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
