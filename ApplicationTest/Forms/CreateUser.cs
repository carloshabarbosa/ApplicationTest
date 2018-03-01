using ApplicationTeste.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest.Forms
{
    public class CreateUser : BaseForm
    {
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

                try
                {
                    UserService.Instance.CreateUser(userName, initialBalance);
                    Console.WriteLine("User created successfully\n");
                    showForm = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Error on create user\n");
                }
            }

            FooterForm();
            new MainMenu().BuildForm();
        }
    }
}
