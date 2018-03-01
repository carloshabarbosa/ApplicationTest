using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest.Forms
{
    public class MainMenu : BaseForm
    {
        public override void BuildForm()
        {
            base.BuildForm();
            base.BuildForm();
            
            while (showForm)
            {
                Console.WriteLine("**************Welcome to ATM Application Test**************");
                Console.WriteLine($"\n\nLogged with: {Program.user.Name}\n\n");
                Console.WriteLine("Please select an option");
                Console.WriteLine("1. List all users");
                Console.WriteLine("2. Create user");
                Console.WriteLine("3. Deposit cash");
                Console.WriteLine("4. Withdraw cash");
                Console.WriteLine("5. View balance");
                Console.WriteLine("0. Save and exit");
                Console.WriteLine("***********************************************************");

                int option = 0;
                if (int.TryParse(Console.ReadLine(), out option))
                {
                    switch (option)
                    {
                        case 1:
                            {

                                showForm = false;
                                new AllUsers().BuildForm();
                                break;
                            }
                        case 2:
                            {

                                showForm = false;
                                new CreateUser().BuildForm();
                                break;
                            }
                        case 3:
                            {

                                showForm = false;
                                new Deposit().BuildForm();
                                break;
                            }
                        case 4:
                            {

                                showForm = false;
                                new Withdraw().BuildForm();
                                break;
                            }
                        case 5:
                            {

                                showForm = false;
                                new Balance().BuildForm();
                                break;
                            }
                        case 0:
                            {
                                showForm = false;
                                Program.user = null;
                                new InitialMenu().BuildForm();
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
            }
        }
    }
}
