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
using WPF.Windows;

namespace WPF
{

    //TODO Fix -  Fav and Opponent goalkeeper are same
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Team> _listTeams;
        static List<Team> _listTeamsOpponents;
        static List<PlayerStatistic> _favoriteListPlayers;
        static List<PlayerStatistic> _opponentListPlayers;
        static string _favoriteTactic = "";
        static string _opponentTactic = "";
        static List<Match> _matchList;
        static Match _currentMatch;
        static Team _favoriteTeam;
        public MainWindow(Settings stgs)
        {
            _listTeams = new List<Team>();
            _favoriteTeam = new Team();
            _listTeamsOpponents = new List<Team>();
            _favoriteListPlayers = new List<PlayerStatistic>();
            _opponentListPlayers = new List<PlayerStatistic>();
            _currentMatch = new Match();
            _matchList = new List<Match>();
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
                _matchList = await Task.Run(() => Repository.GetMatchForSelectedTeam(_favoriteTeam.Fifa_code));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            FillOpponentsList();
            cbFavoriteTeam.ItemsSource = _listTeams;
            cbOpponent.ItemsSource = _listTeamsOpponents;
            cbOpponent.SelectedIndex = 0;


            SetPlayersForCurrentMatch();
            SetGrids();
        }

        private void SetGrids()
        {
            ClearGrids();


            CreateGrid(_favoriteTactic, _favoriteListPlayers, true);
            CreateGrid(_opponentTactic, _opponentListPlayers, false);
        }

        private void ClearGrids()
        {
            gridFavorite.Children.Clear();
            gridOpponent.Children.Clear();
            gridFavorite.ColumnDefinitions.Clear();
            gridOpponent.ColumnDefinitions.Clear();
        }

        private void CreateGrid(string favoriteTactic, List<PlayerStatistic> plyList, bool favorite)
        {
            string[] tmp = favoriteTactic.Split('-');
            int numberOfColumns = tmp.Length + 1;


            int def = int.Parse(tmp[0]);
            int mid = int.Parse(tmp[1]);
            int forw = 10 - (def + mid);

            for (int i = 0; i < numberOfColumns; i++)
            {
                ColumnDefinition cd = new ColumnDefinition();
                if (favorite)
                    gridFavorite.ColumnDefinitions.Add(cd);
                else
                    gridOpponent.ColumnDefinitions.Add(cd);
            }
            if (!favorite)
                gridOpponent.ColumnDefinitions.Add(new ColumnDefinition());
            //Filling goalKeeper
            if (favorite)
                gridFavorite.Children.Add(FillGridWithPlayerCards(plyList, 0, 1, 0));
            else
                gridOpponent.Children.Add(FillGridWithPlayerCards(plyList, 0, 1, numberOfColumns + 1));


            int indexPlayers = 1;
            for (int i = 0; i < numberOfColumns - 1; i++)
            {
                int colIndex = i + 1;
                if (!favorite)
                    colIndex = (numberOfColumns - 1) - i;

                StackPanel sp = new StackPanel();
                sp = FillGridWithPlayerCards(plyList, indexPlayers, indexPlayers + int.Parse(tmp[i]), colIndex);
                gridFavorite.Children.Add(FillGridWithPlayerCards(plyList, 0, 1, 0));
                if (favorite)
                    gridFavorite.Children.Add(sp);
                else
                    gridOpponent.Children.Add(sp);

                indexPlayers += int.Parse(tmp[i]);
            }

        }

        private StackPanel FillGridWithPlayerCards(List<PlayerStatistic> playerList, int from, int to, int collNumber)
        {
            StackPanel sp = new StackPanel();

            for (int i = from; i < to; i++)
            {
                PlayerGridCard pgc = new PlayerGridCard(playerList[i]);
                sp.Children.Add(pgc);
            }

            sp.MinWidth = 100;
            sp.MinHeight = 100;
            sp.Orientation = Orientation.Vertical;
            sp.VerticalAlignment = VerticalAlignment.Center;
            sp.HorizontalAlignment = HorizontalAlignment.Center;
            sp.Margin = new Thickness(5);

            Grid.SetColumn(sp, collNumber);
            return sp;
        }

        private void SetPlayersForCurrentMatch()
        {
            int index = cbOpponent.SelectedIndex;
            _currentMatch = _matchList[index];

            if (_matchList[index].Home_team_country == _favoriteTeam.Country)
            {
                _favoriteListPlayers = _matchList[index].HomeTeamStartingEleven;
                _opponentListPlayers = _matchList[index].AwayTeamStartingEleven;
                _favoriteTactic = _matchList[index].HomeTeamTactic;
                _opponentTactic = _matchList[index].AwayTeamTactic;
            }
            else
            {
                _favoriteListPlayers = _matchList[index].AwayTeamStartingEleven;
                _opponentListPlayers = _matchList[index].HomeTeamStartingEleven;
                _favoriteTactic = _matchList[index].AwayTeamTactic;
                _opponentTactic = _matchList[index].HomeTeamTactic;

            }


        }

        private void FillOpponentsList()
        {
            _listTeamsOpponents.Clear();
            foreach (Match m in _matchList)
            {
                string current = m.Home_team_country == _favoriteTeam.Country ? m.Away_team_country : m.Home_team_country;
                _listTeamsOpponents.Add(_listTeams.Find(x => x.Country == current));
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

        private void CbOpponent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetPlayersForCurrentMatch();
            SetGrids();
        }
    }
}
