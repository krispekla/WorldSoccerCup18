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
        private Settings stgs;
        public SettingsWindow()
        {
            stgs = new Settings();
            InitializeComponent();
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
            faLoading.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Saving settings
            faLoading.Visibility = Visibility.Visible;

            stgs.Language = cbLanguage.SelectedValue.ToString();
            stgs.Height = int.Parse(txtbxHeight.Text);
            stgs.Width = int.Parse(txtbxWidth.Text);
            FileRepository.WriteWPFSettings(stgs);

            var mainWindow = new MainWindow(stgs);
            mainWindow.Show();
            faLoading.Visibility = Visibility.Hidden;

            this.Close();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            base.OnClosed(e);
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
    }
}
