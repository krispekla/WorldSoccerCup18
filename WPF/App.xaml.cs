using DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ApplicationStart(object sender, StartupEventArgs e)
        {
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            string lang = FileRepository.ReadLanguagePreference();
            SetCulture(lang);
            var startWindow = new SettingsWindow(true);
            startWindow.Show();
        }

        private void SetCulture(string language)
        {
            if (language == "English")
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            else if (language == "Hrvatski")
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("hr-HR");
        }

    }
}
