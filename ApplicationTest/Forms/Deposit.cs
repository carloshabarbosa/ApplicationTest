using ApplicationTeste.Service.Services;
using System;

namespace ApplicationTest.Forms
{
    /// <summary>
    /// Class responsible for build the form that deposit cash
    /// </summary>
    public class Deposit : BaseForm
    {
        /// <summary>
        /// Implementation of the abstract class for the form that deposit cash
        /// </summary>
        public override void BuildForm()
        {
            base.BuildForm();

            while (showForm)
            {
                Console.WriteLine($"********Deposit for: {Program.loggedUser.Name}**************\n");
                Console.WriteLine("Enter wwith a amount to deposit:");

                decimal value = 0;
                decimal.TryParse(Console.ReadLine(), out value);

                AccountService.Instance.DepositCash(value, Program.loggedUser);

                Console.WriteLine("Deposit successfully\n");
                showForm = false;
                FooterForm();
                new MainMenu().BuildForm();
                
            }

        }
    }
}
