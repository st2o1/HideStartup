using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;


namespace HideStartupItem
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            SystemEvents.SessionEnding += SystemEvents_SessionEnding;
            SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;

            string keyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\";
            string valueName = "KeyName";

            try
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(keyPath, true);

                if (registryKey != null)
                {
                    if (registryKey.GetValue(valueName) != null)
                    {
                        registryKey.DeleteValue(valueName);
                    }
                    else { }
                    registryKey.Close();
                }
                else { }
            }
            catch { }
        }
        private static void SystemEvents_SessionEnding(object sender, SessionEndingEventArgs e)
        {
            string keyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\";

            using (RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(keyPath))
            {
                if (registryKey != null)
                {
                    registryKey.SetValue("KeyName", "Path To File");
                }
                else { }
            }
        }

        private static void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            string keyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\";

            using (RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(keyPath))
            {
                if (registryKey != null)
                {
                    registryKey.SetValue("KeyName", "Path To File");
                }
                else { }
            }
        }
    }
}
