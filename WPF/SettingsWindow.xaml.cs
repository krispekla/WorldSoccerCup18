using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private MainWindow _openedMain;
        private bool _firstStart;
        private Settings stgs;
        public SettingsWindow(bool start)
        {
            _firstStart = start;
            stgs = new Settings();
            InitializeComponent();
            faLoading.Visibility = Visibility.Visible;
            Parallel.Invoke(() => LoadSettings());
        }

        public SettingsWindow(bool start, MainWindow main)
        {
            _openedMain = main;
            _firstStart = start;
            stgs = new Settings();

            InitializeComponent();

            btnRun.Content = "Save";
            btnExit.Content = "Cancel";
            faLoading.Visibility = Visibility.Visible;
            Parallel.Invoke(() => LoadSettings());
        }

        private void LoadSettings()
        {
            cbLanguage.ItemsSource = new List<String>() { "Hrvatski", "English" };
            Settings loaded = FileRepository.ReadWPFSettings();
            if (loaded != null)
            {
                cbLanguage.SelectedValue = loaded.Language;
                sldHeight.Value = loaded.Height;
                sldWidth.Value = loaded.Width;
                chcbFullscreen.IsChecked = loaded.Fullscreen;
            }

            if (!_firstStart)
            {
                sldHeight.Value = _openedMain.Height;
                sldWidth.Value = _openedMain.Width;
                if (_openedMain.WindowState == WindowState.Maximized)
                    chcbFullscreen.IsChecked = true;
            }

            faLoading.Visibility = Visibility.Hidden;
        }

        private void SaveAndRunClick(object sender, RoutedEventArgs e)
        {
            //Saving settings
            faLoading.Visibility = Visibility.Visible;

            stgs.Language = cbLanguage.SelectedValue.ToString();
            stgs.Height = int.Parse(txtbxHeight.Text);
            stgs.Width = int.Parse(txtbxWidth.Text);
            FileRepository.WriteWPFSettings(stgs);

            if (this._firstStart)
            {
                var mainWindow = new MainWindow(stgs);
                mainWindow.Show();
            }
            else
            {
                _openedMain.Height = sldHeight.Value;
                _openedMain.Width = sldWidth.Value;

                if (stgs.Fullscreen)
                    _openedMain.WindowState = WindowState.Maximized;
            }

            faLoading.Visibility = Visibility.Hidden;

            this.Close();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            base.OnClosed(e);

            if (_firstStart)
                Application.Current.Shutdown();
        }

        private void ChcbFullscreen_Unchecked(object sender, RoutedEventArgs e)
        {
            stgs.Fullscreen = false;
        }

        private void ChcbFullscreen_Checked(object sender, RoutedEventArgs e)
        {
            stgs.Fullscreen = true;
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SaveAndRunClick(sender, e);
            }
            else if (e.Key == Key.Escape)
            {
                BtnExit_Click(sender, e);
            }
        }
    }
}
