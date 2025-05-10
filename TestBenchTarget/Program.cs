using System;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;
using System.Runtime.Versioning; // Pridajte tento import

namespace TestBenchTarget
{
    // Pridajte tento atribút na úrovni triedy
    [SupportedOSPlatform("windows")]
    internal static class Program
    {
        private static string mutexName = "com.rudolfmendzezof.testbenchtarget";
        private static Mutex? mutex;

        [STAThread]
        static void Main()
        {
            // Application settings for modern Windows Forms
            ApplicationConfiguration.Initialize();

            // Set English culture globally for all threads
            CultureInfo ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = ci;
            Thread.CurrentThread.CurrentCulture = ci;
            CultureInfo.DefaultThreadCurrentCulture = ci;
            CultureInfo.DefaultThreadCurrentUICulture = ci;

            // High DPI support is now built into .NET
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);

            // Ensure only one instance runs
            bool createdNew;
            mutex = new Mutex(true, mutexName, out createdNew);

            if (!createdNew)
            {
                MessageBox.Show("The application is already running.", "TestBench Target",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            finally
            {
                mutex?.ReleaseMutex();
                mutex?.Dispose();
            }
        }
    }
}
