using RoboMate.Controller;
using RoboMate.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboMate
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var configuartion=ConfigController.GetConfigController().Configurations;
            ComponentConfigurator.GetComponentConfigurator().Initialize(configuartion);

            Application.Run(new TrayIconApplicationContext());
        }
    }
}
