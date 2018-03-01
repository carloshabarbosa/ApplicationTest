using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest.Forms
{
    public class InitialMenu : BaseForm
    {
        public override void BuildForm()
        {
            base.BuildForm();
            var showMainMenu = true;
            while (showMainMenu)
            {
                Console.WriteLine("**************Welcome to ATM Application Test**************\n");
                Console.WriteLine("Please select a option");
                Console.WriteLine("1. Login with valid user ");
                Console.WriteLine("0. Exit\n");
                Console.WriteLine("************************************************************");

                int option = 0;
                if (int.TryParse(Console.ReadLine(), out option))
                {
                    switch (option)
                    {
                        case 1:
                            {

                                showMainMenu = false;
                                new Login().BuildForm();
                                break;
                            }
                        case 0:
                            {
                                showMainMenu = false;
                                Environment.Exit(0);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid option!");
                                FooterForm();
                                Console.Clear();
                                break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option!");
                    FooterForm();
                    Console.Clear();

                }
            }
        }
    }
}
