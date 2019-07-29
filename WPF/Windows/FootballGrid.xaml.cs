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
    /// Interaction logic for FootballGrid.xaml
    /// </summary>
    public partial class FootballGrid : UserControl
    {
        private List<PlayerStatistic> players = new List<PlayerStatistic>();
        public FootballGrid(List<PlayerStatistic> pList)
        {
            InitializeComponent();
            players = SortByPosition(pList);

            List<PlayerGridCard> listOfCards = new List<PlayerGridCard>();


            // Create Columns

            ColumnDefinition gridCol1 = new ColumnDefinition();

            ColumnDefinition gridCol2 = new ColumnDefinition();

            ColumnDefinition gridCol3 = new ColumnDefinition();

            gridPl.ColumnDefinitions.Add(gridCol1);

            gridPl.ColumnDefinitions.Add(gridCol2);

            gridPl.ColumnDefinitions.Add(gridCol3);



            // Create Rows

            RowDefinition gridRow1 = new RowDefinition();

            gridRow1.Height = new GridLength(45);

            RowDefinition gridRow2 = new RowDefinition();

            gridRow2.Height = new GridLength(45);

            RowDefinition gridRow3 = new RowDefinition();

            gridRow3.Height = new GridLength(45);

            gridPl.RowDefinitions.Add(gridRow1);

            gridPl.RowDefinitions.Add(gridRow2);

            gridPl.RowDefinitions.Add(gridRow3);

            foreach (PlayerStatistic item in players)
            {
                PlayerGridCard p = new PlayerGridCard(item);
                listOfCards.Add(p);
                p.Width = 100;
                p.Height = 100;
                
                p.VerticalAlignment = VerticalAlignment.Top;
                p.HorizontalAlignment = HorizontalAlignment.Left;
                gridPl.Children.Add(p);
            }


           

        }

        private List<PlayerStatistic> SortByPosition(List<PlayerStatistic> pList)
        {
            List<PlayerStatistic> temp = new List<PlayerStatistic>();
            List<PlayerStatistic> def = new List<PlayerStatistic>();
            List<PlayerStatistic> mid = new List<PlayerStatistic>();
            List<PlayerStatistic> forw = new List<PlayerStatistic>();

            foreach (PlayerStatistic item in pList)
            {
                switch (item.Position)
                {
                    case "Goalie":
                        temp.Add(item);
                        break;
                    case "Defender":
                        def.Add(item);
                        break;
                    case "Midfield":
                        mid.Add(item);
                        break;
                    case "Forward":
                        forw.Add(item);

                        break;
                    default:
                        break;
                }
            }
            temp.AddRange(def);
            temp.AddRange(mid);
            temp.AddRange(forw);

            return temp;
        }
    }
}
