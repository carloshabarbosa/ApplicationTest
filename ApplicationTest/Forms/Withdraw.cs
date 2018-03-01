using ApplicationTeste.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest.Forms
{
    public class Withdraw : BaseForm
    {
        public override void BuildForm()
        {
            base.BuildForm();
            while (showForm)
            {
                Console.WriteLine($"********Withdraw for: {Program.user.Name}**************\n");

                Console.WriteLine($"Balance: {Program.user.Account.Balance}");
                Console.WriteLine("Enter wwith a amount to withdraw:");

                decimal value = 0;
                decimal.TryParse(Console.ReadLine(), out value);

                var response = AccountService.Instance.WithdrawCash(value, Program.user);

                Console.WriteLine($"{response}\n");
                showForm = false;
                FooterForm();
                new MainMenu().BuildForm();

            }
        }
    }
}
