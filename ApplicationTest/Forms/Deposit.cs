using ApplicationTeste.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest.Forms
{
    public class Deposit : BaseForm
    {
        public override void BuildForm()
        {
            base.BuildForm();

            while (showForm)
            {
                Console.WriteLine($"********Deposit for: {Program.user.Name}**************\n");
                Console.WriteLine("Enter wwith a amount to deposit:");

                decimal value = 0;
                decimal.TryParse(Console.ReadLine(), out value);

                AccountService.Instance.DepositCash(value, Program.user);

                Console.WriteLine("Deposit successfully\n");
                showForm = false;
                FooterForm();
                new MainMenu().BuildForm();
                
            }

        }
    }
}
