using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest.Forms
{
    public abstract class BaseForm
    {
        protected bool showForm = true;
        public virtual void BuildForm()
        {
            showForm = true;
            Console.Clear();
        }
        protected void FooterForm()
        {
            Console.WriteLine("Press any key!");
            Console.ReadKey();
        }
    }
}
