using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Furniture.Models;

namespace Furniture
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Customer a = new Customer();
           // Console.WriteLine("name:");
           // Application.Run(new FormOrder());
          // Application.Run(new FormEmployee());
           // Application.Run(new FormProduct());
           
           Application.Run(new Login());
           // Application.Run(new Admin());
        }
    }
}
