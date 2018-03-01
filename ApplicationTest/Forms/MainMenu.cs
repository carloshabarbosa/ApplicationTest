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
            var showMainMenu = true;
            while (showMainMenu)
            {
                Console.WriteLine("********Welcome to ATM Application Test**************\n");
                Console.WriteLine("Please select an option");
                Console.WriteLine("1. List all users");
                Console.WriteLine("2. Create user");
                Console.WriteLine("3. Deposit cash");
                Console.WriteLine("4. Withdraw cash");
                Console.WriteLine("0. Save and exit");
                Console.WriteLine("******************************************************");

                int option = 0;
                if (int.TryParse(Console.ReadLine(), out option))
                {
                    switch (option)
                    {
                        case 1:
                            {

                                showMainMenu = false;
                                new AllUsers().BuildForm();
                                break;
                            }
                        case 2:
                            {

                                showMainMenu = false;
                                new Login().BuildForm();
                                break;
                            }
                        case 3:
                            {

                                showMainMenu = false;
                                new Login().BuildForm();
                                break;
                            }
                        case 4:
                            {

                                showMainMenu = false;
                                new Login().BuildForm();
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
