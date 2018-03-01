using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest.Forms
{
    public class Balance : BaseForm
    {
        public override void BuildForm()
        {
            base.BuildForm();

            Console.WriteLine($"Balance: {Program.user.Account.Balance}");

            FooterForm();

            new MainMenu().BuildForm();

        }
    }
}
