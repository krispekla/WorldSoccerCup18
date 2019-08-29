using DAL.Models;
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
    /// Interaction logic for PlayerDetails.xaml
    /// </summary>
    public partial class PlayerDetails : Window
    {
        public PlayerDetails(PlayerStatistic pl)
        {
            InitializeComponent();
            lbName.Content = pl.Name;
            lbNumber.Content = pl.Shirt_number;
            lbPosition.Content = pl.Position;
            lbCaptain.Content = pl.Captain;
            lbGoals.Content = pl.Goals;
            lbYellow.Content = pl.Yellow_cards;

            if (!String.IsNullOrEmpty(pl.Image))
            {
                Uri i = new Uri(pl.Image);
                imgPlyer.Source = new BitmapImage(i);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Escape)
            {
                this.Close();
            }
        }
    }
}
