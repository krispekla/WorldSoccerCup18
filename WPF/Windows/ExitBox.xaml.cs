using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF.Windows
{
    /// <summary>
    /// Interaction logic for ExitBox.xaml
    /// </summary>
    public partial class ExitBox : Window
    {
        public ExitBox()
        {
            InitializeComponent();
        }

        private void ConfirmClick(object sender, RoutedEventArgs e)
        {
            this.Close();
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            exitBx.Close();
        }

        private void ExitBx_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ConfirmClick(sender, e);
            }
            else if (e.Key == Key.Escape)
            {
                CancelClick(sender, e);
            }
        }
    }
}
