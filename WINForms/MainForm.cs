using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WINForms.Controls;
using WINForms.Forms;
using WINForms.Utils;

namespace WINForms
{
    public partial class MainForm : Form
    {
        private List<Team> _teams;
        private List<Player> _currentPlayers;
        private Team _favoriteTeam;
        private int _apiCallsCounter = 0;
        private int _favoritesNum = 0;
        private List<Player> _selected;
        private string _selectingFavorite = "";

        public MainForm()
        {
            _teams = new List<Team>();
            _favoriteTeam = new Team();
            _currentPlayers = new List<Player>();
            _selected = new List<Player>();

            InitializeComponent();
            ucTeamSelect.BtnSetFavoriteClick += UcTeamSelect_BtnSetFavoriteClick;
            ucTeamSelect.CbTeamsListSelectedValueChanged += UcTeamSelect_CbTeamsListSelectedValueChanged;


            backgroundWorkerInit.RunWorkerAsync();

        }

        private void UcTeamSelect_CbTeamsListSelectedValueChanged(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            ucTeamSelect.Enabled = false;
            string code = Helper.GetCountryCode((String)(ucTeamSelect.cbTeamsList.SelectedItem));
            if (!backgroundWorkerGetPlayersByCode.IsBusy)
                backgroundWorkerGetPlayersByCode.RunWorkerAsync(code);
            //BackgroundWorkerGetPlayersByCode.RunWorkerAsync(code);
            //ucPlayersList.SelectedTeam = teams[ucFavoriteTeam.cbTeamsList.SelectedIndex];
            ////ucPlayersList.Players = currentPlayers;
            //ucPlayersList.DisplayPlayersList();
        }

        private void UcTeamSelect_BtnSetFavoriteClick(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            Enabled = false;
            string code = (((String)(ucTeamSelect.cbTeamsList.SelectedItem)).Split()).Last();
            _favoriteTeam = _teams.Find(y => y.Fifa_code == code);
            backgroundWorkerSaveFavoriteTeam.RunWorkerAsync();
        }

        //Background workers
        private void BackgroundWorkerInit_DoWork(object sender, DoWorkEventArgs e)
        {
            UseWaitCursor = true;

            List<Team> tms = Repository.GetTeams().Result;
            if (tms != null)
                _teams = tms;

            e.Result = FileRepository.GetFavoriteTeam();

        }

        private void BackgroundWorkerInit_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Canceled");
            }
            else
            {
                if (e.Result == null || _teams == null)
                {
                    if (_apiCallsCounter <= 5)
                        backgroundWorkerInit.RunWorkerAsync();

                    _apiCallsCounter++;
                    UseWaitCursor = false;
                    Enabled = true;
                    return;
                }

                if (!String.IsNullOrEmpty((String)e.Result))
                {
                    string teamName = Helper.GetCountryNameWithoutCode((String)e.Result);
                    ucTeamSelect.LoadTeamsAndFavorite(_teams, teamName);
                }
                else
                    ucTeamSelect.LoadTeamsAndFavorite(_teams, null);

            }
            _apiCallsCounter = 0;
            UseWaitCursor = false;
            Enabled = true;

        }

        private void BackgroundWorkerSaveFavoriteTeam_DoWork(object sender, DoWorkEventArgs e)
        {
            FileRepository.SaveFavoriteTeam(_favoriteTeam.TeamName());
        }

        private void BackgroundWorkerSaveFavoriteTeam_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Canceled");
            }

            UseWaitCursor = false;
            Enabled = true;
        }

        private void BackgroundWorkerGetPlayersByCode_DoWork(object sender, DoWorkEventArgs e)
        {
            string code = (String)e.Argument;
            if (String.IsNullOrEmpty(code))
            {
                backgroundWorkerGetPlayersByCode.CancelAsync();
                return;
            }

            e.Result = Repository.GetPlayersByCodeAsync(code).Result;

        }

        private void BackgroundWorkerGetPlayersByCode_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Canceled");
            }
            else
            {
                if (e.Result == null)
                {
                    if (_apiCallsCounter <= 5)
                    {
                        string code = Helper.GetCountryCode((String)(ucTeamSelect.cbTeamsList.SelectedItem));
                        backgroundWorkerGetPlayersByCode.RunWorkerAsync(code);
                    }
                    return;
                }

                _currentPlayers = (List<Player>)e.Result;
                LoadPlayersIntoControls();

            }
            _apiCallsCounter = 0;
            ucTeamSelect.Enabled = true;
            UseWaitCursor = false;
        }

        //
        private void LoadPlayersIntoControls()
        {
            UseWaitCursor = true;
            Enabled = false;

            flAllPlayers.Controls.Clear();
            flFavoritePlayers.Controls.Clear();
            _favoritesNum = 0;

            List<Control> plList = new List<Control>();

            foreach (Player p in _currentPlayers)
            {
                PlayerDetails pd = new PlayerDetails();
                pd.ShowPlayerDetails(p);
                if (p.Favorite)
                {
                    _favoritesNum++;
                    pd.ContextMenuStrip = cmPlayersFav;
                    pd.PlayerDetailsClick += Pd_PlayerDetailsClickFav;
                }
                else
                {
                    pd.ContextMenuStrip = cmPlayersAll;
                    pd.PlayerDetailsClick += Pd_PlayerDetailsClickAll;
                }
                plList.Add(pd);
            }
            SortAndDisplayPlayersControls(plList);
        }

        private void Pd_PlayerDetailsClickFav(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;


            if (String.IsNullOrEmpty(_selectingFavorite))
                _selectingFavorite = "Fav";

            else if (_selectingFavorite != "Fav") return;

            PlayerDetails curr = sender as PlayerDetails;

            if (curr.IsSelected)
            {
                ParseAndRemovePlayer(curr);
                if (_selected.Count == 0) _selectingFavorite = "";
                curr.SetSelected();
            }
            else if (_selected.Count == 3)
            {
                return;
            }
            else
            {
                ParseAndAddPlayer(curr);
                curr.SetSelected();
            }
        }

        private void Pd_PlayerDetailsClickAll(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right || _favoritesNum == 3) return;

            if (String.IsNullOrEmpty(_selectingFavorite))
                _selectingFavorite = "All";

            else if (_selectingFavorite != "All") return;

            PlayerDetails curr = sender as PlayerDetails;

            if (curr.IsSelected)
            {
                ParseAndRemovePlayer(curr);
                if (_selected.Count == 0) _selectingFavorite = "";
                curr.SetSelected();
            }
            else if (_selected.Count == 3)
            {
                return;
            }
            else
            {
                ParseAndAddPlayer(curr);
                curr.SetSelected();
            }
        }

        private void ParseAndAddPlayer(PlayerDetails curr)
        {
            Player p = new Player()
            {
                Name = curr.lbName.Text,
                Shirt_number = int.Parse(curr.lbShirtNumber.Text),
                Favorite = (curr.Name.ToString().Substring(curr.Name.Length - 1) == "*") ? true : false
            };
            _selected.Add(p);
        }

        private void ParseAndRemovePlayer(PlayerDetails curr)
        {
            List<Player> copy = new List<Player>();

            foreach (Player item in _selected)
            {
                if (item.Shirt_number != int.Parse(curr.lbShirtNumber.Text))
                {
                    copy.Add(item);
                }
            }
            _selected = copy;
        }

        private void SortAndDisplayPlayersControls(List<Control> plList)
        {
            flAllPlayers.Controls.Clear();
            flFavoritePlayers.Controls.Clear();

            foreach (PlayerDetails p in plList)
            {
                if (p.Favorite)
                    flFavoritePlayers.Controls.Add(p);
                else
                    flAllPlayers.Controls.Add(p);
            }
            UseWaitCursor = false;
            Enabled = true;
            Refresh();
        }

        private void CmPlayers_Opened(object sender, EventArgs e)
        {
            if (_selected.Count != 0) return;
            PlayerDetails plD = (sender as ContextMenuStrip).SourceControl as PlayerDetails;

            Player p = new Player()
            {
                Name = plD.Name,
                Shirt_number = int.Parse(plD.lbShirtNumber.Text),
                Favorite = (plD.Name.ToString().Substring(plD.Name.Length - 1) == "*") ? true : false
            };

            if (_selected.Count < 3)
                _selected.Add(p);
        }

        private void CmChangeToFavorites_Click(object sender, EventArgs e)
        {
            if (!CanBeTransfered()) return;

            _selectingFavorite = "";
            UpdatePlayersList();
            LoadPlayersIntoControls();
        }

        private void UpdatePlayersList()
        {
            foreach (Player item in _selected)
            {
                int ind = _currentPlayers.FindIndex(x => x.Shirt_number == item.Shirt_number);
                if (ind != -1)
                    _currentPlayers[ind].Favorite = !_currentPlayers[ind].Favorite;
            }
            _selected.Clear();
        }

        private bool CanBeTransfered()
        {
            int otherCount = _selected.Count;
            int favCount = _favoritesNum;

            int sum = otherCount + favCount;

            if (sum < -1 || sum > 3) return false;
            if (sum > 0 && sum <= 3) return true;

            return false;
        }

        private void RemoveAllFromFavorites(object sender, EventArgs e)
        {
            List<Player> copy = new List<Player>();
            foreach (Player item in _currentPlayers)
            {
                item.Favorite = false;
                copy.Add(item);
            }
            _currentPlayers = copy;
            _selected.Clear();
            _favoritesNum = 0;
            _selectingFavorite = "";
            LoadPlayersIntoControls();
        }

        private void CmRemoveFromFavoritesClick(object sender, EventArgs e)
        {
            _selectingFavorite = "";
            UpdatePlayersList();
            LoadPlayersIntoControls();
        }
    }
}
