using System;

namespace ApplicationTest.Forms
{
    /// <summary>
    /// Class responsible for build the main menu form
    /// </summary>
    public class MainMenu : BaseForm
    {
        /// <summary>
        /// Implementation of the abstract class for the main menu form
        /// </summary>
        public override void BuildForm()
        {
            base.BuildForm();
            base.BuildForm();
            
            while (showForm)
            {
                Console.WriteLine("**************Welcome to ATM Application Test**************");
                Console.WriteLine($"\n\nLogged with: {Program.loggedUser.Name}\n\n");
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
                                Program.loggedUser = null;
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
