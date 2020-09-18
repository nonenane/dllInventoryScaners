using Nwuram.Framework.Settings.Connection;
using Nwuram.Framework.Logging;
using Nwuram.Framework.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace dllInventoryScaners
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Project.FillSettings(args);
                Application.EnableVisualStyles();
                Logging.Init(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);
                Application.SetCompatibleTextRenderingDefault(false);
                Logging.StartFirstLevel(1);
                Logging.Comment("Вход в программу");
                Logging.StopFirstLevel();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMainForm());
                Logging.StartFirstLevel(2);
                Logging.Comment("Выход из программы");
                Logging.StopFirstLevel();

                Project.clearBufferFiles();
            }
        }
    }
}
