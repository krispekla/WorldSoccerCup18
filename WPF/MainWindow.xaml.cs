using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Team> _listTeams;
        static List<Team> _listTeamsOpponents;
        static List<Player> _favoriteListPlayers;
        static List<Player> _opponentListPlayers;
        static List<Match> _matchList;
        static Match _currentMatch;
        static Team _favoriteTeam;
        static int _selectedOpponentIndex;
        public MainWindow(Settings stgs)
        {
            _listTeams = new List<Team>();
            _favoriteTeam = new Team();
            _listTeamsOpponents = new List<Team>();
            _favoriteListPlayers = new List<Player>();
            _opponentListPlayers = new List<Player>();
            _currentMatch = new Match();
            _matchList = new List<Match>();
            _selectedOpponentIndex = new int();
            InitializeComponent();

            SetWindowSettings(stgs);
            LoadTeams();

        }

        private async void LoadTeams()
        {
            var teamsList = await Task.Run(() => Repository.GetTeams().Result);
            _listTeams = (List<Team>)teamsList;
            LoadFavorite();
        }

        private async void LoadFavorite()
        {
            string favoriteTeam = await Task.Run(() => FileRepository.GetFavoriteTeam());

            if (favoriteTeam == null)
            {
                SetFavoriteTeamUI(_listTeams[0].TeamName());
            }
            else
                SetFavoriteTeamUI(favoriteTeam);

        }

        private void SetFavoriteTeamUI(string favoriteTeam)
        {
            string[] temp = favoriteTeam.Split();
            string tmpName = "";
            for (int i = 0; i < temp.Length - 1; i++)
            {
                tmpName += temp[i];
            }
            _favoriteTeam = _listTeams.Find(tm => tm.Country == tmpName);
            cbFavoriteTeam.SelectedItem = _favoriteTeam;
            SetOpponents();
        }

        private async void SetOpponents()
        {
            _matchList.Clear();
            _listTeamsOpponents.Clear();
            try
            {
                //_favoriteListPlayers = await Task.Run(() => Repository.GetPlayersByCodeAsync("GER"));
                //_matchList = await Task.Run(() => Repository.GetMatchesForSelectedTeam());
         
                _matchList = await Task.Run(() => Repository.GetMatchForSelectedTeam(_favoriteTeam.Fifa_code));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            FillOpponentsList();
            cbFavoriteTeam.ItemsSource = _listTeams;
            cbOpponent.ItemsSource = _listTeamsOpponents;
        }

        private void FillOpponentsList()
        {
            _listTeamsOpponents.Clear();
            foreach (Match m in _matchList)
            {
                string current = m.Home_team_country == _favoriteTeam.Country ? m.Away_team_country : m.Home_team_country;
                _listTeamsOpponents.Add(_listTeams.Find(x => x.Country == current));
            }
            if (cbOpponent.SelectedIndex != 0)
            {
                cbOpponent.SelectedIndex = 0;
                _selectedOpponentIndex = 0;
            }
            else
            {
                string[] temp = cbOpponent.SelectedValue.ToString().Split();
                _selectedOpponentIndex = _matchList.FindIndex(t => t.Home_team_country.Split()[0] == temp[0]);
            }
            cbOpponent.Items.Refresh();
        }

        private void SetWindowSettings(Settings stgs)
        {
            if (stgs.Fullscreen)
                this.WindowState = WindowState.Maximized;

            Width = stgs.Width;
            Height = stgs.Height;
            SetCulture(stgs.Language);
        }

        private void SetCulture(string language)
        {
            if (language == "English")
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
            else if (language == "Hrvatski")
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("hr-HR");
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private async void CbFavoriteTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _favoriteTeam = (Team)cbFavoriteTeam.SelectedValue;

            if (!String.IsNullOrEmpty(_favoriteTeam.TeamName()))
                await Task.Run(() => FileRepository.SaveFavoriteTeam(_favoriteTeam.TeamName()));

            SetOpponents();


            //_currentMatch = await Task.Run(() => Repository.GetMatchForSelectedTeam(_favoriteTeam.Fifa_code, _selectedOpponentIndex));
        }

        private void BtnFavoriteTeamInfo_Click(object sender, RoutedEventArgs e)
        {
            if (_favoriteTeam != null)
            {
                TeamDetails td = new TeamDetails(_favoriteTeam);
                td.ShowDialog();
            }
        }

        private void BtnOpponentInfo_Click(object sender, RoutedEventArgs e)
        {
            if (cbOpponent.SelectedItem.GetType() == typeof(Team))
            {
                TeamDetails td = new TeamDetails((Team)cbOpponent.SelectedItem);
                td.ShowDialog();
            }
        }

        private void FaExit_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ExitBox exbox = new ExitBox();
            exbox.ShowDialog();
        }
    }
}
