using System;

namespace ApplicationTest.Forms
{
    /// <summary>
    /// Class responsible for build the form that bring the current balance
    /// </summary>
    public class Balance : BaseForm
    {
        /// <summary>
        /// Implementation of the abstract class for the current balance
        /// </summary>
        public override void BuildForm()
        {
            base.BuildForm();

            Console.WriteLine($"Balance: {Program.loggedUser.Account.Balance}");

            FooterForm();

            new MainMenu().BuildForm();

        }
    }
}
