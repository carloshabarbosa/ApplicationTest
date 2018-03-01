using System;

namespace ApplicationTest.Forms
{
    /// <summary>
    /// Abstract class reponsible for build all forms
    /// </summary>
    public abstract class BaseForm
    {
        /// <summary>
        /// Variable responsible for control the form exibition
        /// </summary>
        protected bool showForm = true;

        /// <summary>
        /// Virtual method that contains the initial config for the forms
        /// </summary>
        public virtual void BuildForm()
        {
            showForm = true;
            Console.Clear();
        }

        /// <summary>
        /// Method responsible for build the default footer in the application
        /// </summary>
        protected void FooterForm()
        {
            Console.WriteLine("Press any key!");
            Console.ReadKey();
        }
    }
}
