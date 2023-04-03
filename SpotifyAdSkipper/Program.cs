using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotifyAdSkipper
{
    internal static class Program
    {
        public static System.Drawing.Icon Icon = Properties.Resources.Icon;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger.Clear();
            AdDetection.AdDetector.LoadAdDetectionFiltersFromFile();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CreateTrayIcon();

            Timer AdSkipTimer = new Timer();
            AdSkipTimer.Interval = 500;
            AdSkipTimer.Enabled = true;
            AdSkipTimer.Tick += AdSkipTimer_Tick;

            Application.Run();
        }

        static void CreateTrayIcon() 
        {
            NotifyIcon trayIcon = new NotifyIcon();
            trayIcon.Icon = Icon;
            trayIcon.Click += TrayIcon_Click;
            trayIcon.Visible = true;

            ContextMenu contextMenu = new ContextMenu(
                new MenuItem[]
                {
                    new MenuItem("Exit", (a, b) => Application.Exit())
                }
            );
            trayIcon.ContextMenu = contextMenu;
        }

        private static void AdSkipTimer_Tick(object sender, EventArgs e)
        {
            SpotifyController.SkipIfPlayingAd();
        }

        private static void TrayIcon_Click(object sender, EventArgs e)
        {
            AdSkipperInfoForm adSkipperInfoForm = new AdSkipperInfoForm();
            adSkipperInfoForm.Show();
            adSkipperInfoForm.ScrollLogToBottom();
        }
    }
}
