using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlbeFly.BoardControl;

namespace AlbeFly.BoardControl
{
    static class AppLoader
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool mutexIsNew;

            Logger _logger = Logger.GetInstance();

            using (System.Threading.Mutex m = new System.Threading.Mutex(true, Defs.APP_GUID, out mutexIsNew))
            {
                if (!mutexIsNew)
                {
                    MessageBox.Show("Application is already running", Defs.MAIN_FORM_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    WindowActivator.ActivateWindow(MainForm.GetCaption());

                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                MainForm mainForm = new MainForm();
                _logger.MemLog += mainForm.OnMemLog; // MemLog subscriber

                MainServer mainServerClass = new MainServer();
                             
                mainForm.closeAppDelegate = mainServerClass.CloseApp; // CloseApp delegate   
                mainForm.getBoardInfoDelegate = mainServerClass.GetBoardInfo;

                mainServerClass.formInitDelegate = mainForm.FormInit; // Init delegate
                mainServerClass.formAddBoardDelegate = mainForm.FormAddBoard; // Add board delegate
                mainServerClass.formSelectBoard = mainForm.FormSelectBoard; // Delegate to select needed board on form and show all info about that board


                mainServerClass.Init();             
                               
                Application.Run(mainForm);
            }
        }
    }
}
