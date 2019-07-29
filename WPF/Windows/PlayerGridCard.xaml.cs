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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF.Windows
{
    /// <summary>
    /// Interaction logic for PlayerGridCard.xaml
    /// </summary>
    public partial class PlayerGridCard : UserControl
    {
        private PlayerStatistic ps = new PlayerStatistic();
        public PlayerGridCard(PlayerStatistic pl)
        {
            ps = pl;
            InitializeComponent();
            lbName.Content = pl.Name;
            lbNumber.Content = pl.Shirt_number;

            if (!String.IsNullOrEmpty(pl.Image))
            {
                Uri i = new Uri(pl.Image);
                imgPlyer.Source = new BitmapImage(i);
            }
        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            PlayerDetails pd = new PlayerDetails(ps);
            pd.ShowDialog();
        }
    }
}
