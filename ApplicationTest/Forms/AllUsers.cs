using ApplicationTeste.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest.Forms
{
    public class AllUsers : BaseForm
    {
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
            Console.WriteLine("Press any key to return to main menu!");
            Console.ReadKey();

            new MainMenu().BuildForm();
        }
    }
}
