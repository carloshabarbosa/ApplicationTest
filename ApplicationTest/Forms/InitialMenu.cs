using System;

namespace ApplicationTest.Forms
{
    /// <summary>
    /// Class responsible for build the initial menu
    /// </summary>
    public class InitialMenu : BaseForm
    {
        /// <summary>
        /// Implementation of the abstract class for the initial menu form
        /// </summary>
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
