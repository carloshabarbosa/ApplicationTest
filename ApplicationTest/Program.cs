using ApplicationTest.Data.Entities;
using ApplicationTest.Forms;

namespace ApplicationTest
{
    /// <summary>
    /// Start point of application
    /// </summary>
    class Program
    {
        /// <summary>
        /// Variable responsible for stored the logged user
        /// </summary>
        public static User loggedUser;
        /// <summary>
        /// Main metho to start the application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            new InitialMenu().BuildForm();
        }
    }
}
