using System;
using System.Windows.Forms;

namespace Space_Invaders
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}