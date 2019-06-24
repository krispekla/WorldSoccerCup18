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
        public MainForm()
        {
            _teams = new List<Team>();
            _favoriteTeam = new Team();
            _currentPlayers = new List<Player>();
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

        private void LoadPlayersIntoControls()
        {
            UseWaitCursor = true;
            Enabled = false;
            flAllPlayers.Controls.Clear();
            flFavoritePlayers.Controls.Clear();
            List<Control> plList = new List<Control>();
            foreach (Player p in _currentPlayers)
            {
                PlayerDetails pd = new PlayerDetails();
                pd.ShowPlayerDetails(p);
                plList.Add(pd);
            }
            SortAndDisplayPlayersControls(plList);
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
    }
}
