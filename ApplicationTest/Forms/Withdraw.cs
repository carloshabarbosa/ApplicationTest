using ApplicationTeste.Service.Services;
using System;

namespace ApplicationTest.Forms
{
    /// <summary>
    /// Class responsible for build the form that withdraw cash
    /// </summary>
    public class Withdraw : BaseForm
    {
        /// <summary>
        /// Implementation of the abstract class for the form that withdraw cash
        /// </summary>
        public override void BuildForm()
        {
            base.BuildForm();
            while (showForm)
            {
                Console.WriteLine($"********Withdraw for: {Program.loggedUser.Name}**************\n");

                Console.WriteLine($"Balance: {Program.loggedUser.Account.Balance}");
                Console.WriteLine("Enter wwith a amount to withdraw:");

                decimal value = 0;
                decimal.TryParse(Console.ReadLine(), out value);

                var response = AccountService.Instance.WithdrawCash(value, Program.loggedUser);

                Console.WriteLine($"{response}\n");
                showForm = false;
                FooterForm();
                new MainMenu().BuildForm();

            }
        }
    }
}
