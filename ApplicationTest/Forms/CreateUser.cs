using ApplicationTeste.Service.Services;
using System;

namespace ApplicationTest.Forms
{
    /// <summary>
    /// Class responsible for build the form that create an user
    /// </summary>
    public class CreateUser : BaseForm
    {
        /// <summary>
        /// Implementation of the abstract class for the form that creates an user
        /// </summary>
        public override void BuildForm()
        {
            base.BuildForm();

            while (showForm)
            {
                Console.WriteLine("********All users**************\n");
                Console.WriteLine("Enter with a USERNAME: ");

                var userName = Console.ReadLine();

                Console.WriteLine("Enter with a INITIAL BALANCE: ");

                decimal initialBalance = 0;
                decimal.TryParse(Console.ReadLine().ToString(), out initialBalance);

                UserService.Instance.CreateUser(userName, initialBalance);
                Console.WriteLine("User created successfully\n");
                showForm = false;
            }

            FooterForm();
            new MainMenu().BuildForm();
        }
    }
}
