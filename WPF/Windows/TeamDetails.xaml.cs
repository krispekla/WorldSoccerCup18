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
    /// Interaction logic for TeamDetails.xaml
    /// </summary>
    public partial class TeamDetails : Window
    {
        private static Team _team;
        public TeamDetails(Team tm)
        {
            _team = new Team(tm);
            InitializeComponent();
            lbCountryName.Content = _team.Country;
            lbFIFACode.Content = _team.Fifa_code;
            lbMatchesPlayed.Content = _team.Games_played;
            lbWins.Content = _team.Wins;
            lbLoses.Content = _team.Losses;
            lbDraws.Content = _team.Draws;

            lbGoalsScored.Content = _team.Goals_for;
            lbGoalsReceived.Content = _team.Goals_against;
            lbGoalsDifferential.Content = _team.Goal_differential;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
