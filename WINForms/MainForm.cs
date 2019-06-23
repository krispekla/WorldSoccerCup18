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
using WINForms.Forms;
using WINForms.Utils;

namespace WINForms
{
    public partial class MainForm : Form
    {
        private List<Team> _teams;
        private List<Player> _currentPlayers;
        private Team _favoriteTeam;

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
            //favoriteTeam = ucFavoriteTeam.FavTeam;
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
            _teams = Repository.GetTeams().Result;
            e.Result = FileRepository.GetFavoriteTeam();
        }

        private void BackgroundWorkerInit_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                UseWaitCursor = false;
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                UseWaitCursor = false;
                MessageBox.Show("Canceled");
            }
            else
            {

                if (!String.IsNullOrEmpty((String)e.Result))
                {
                    string teamName = Helper.GetCountryNameWithoutCode((String)e.Result);
                    ucTeamSelect.LoadTeamsAndFavorite(_teams, teamName);
                }
                else
                    ucTeamSelect.LoadTeamsAndFavorite(_teams, null);


                UseWaitCursor = false;
                Enabled = true;
            }

        }

        private void BackgroundWorkerSaveFavoriteTeam_DoWork(object sender, DoWorkEventArgs e)
        {
            FileRepository.SaveFavoriteTeam(_favoriteTeam.TeamName());
        }

        private void BackgroundWorkerSaveFavoriteTeam_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                UseWaitCursor = false;
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                UseWaitCursor = false;
                MessageBox.Show("Canceled");
            }
            else
            {
                UseWaitCursor = false;
                Enabled = true;
            }
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
                UseWaitCursor = false;
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                UseWaitCursor = false;
                MessageBox.Show("Canceled");
            }
            else
            {
                _currentPlayers = (List<Player>)e.Result;

                //Kada se rijese custom kontrole i njihov display, zatim srediti ovaj dio i nakon
                //toga od UcTeamSelect_CbTeamsListSelectedValueChanged do kraja
                //ucPlayerDetails.CurrentPlayers = currentPlayers;
                //ucPlayersList.Players = currentPlayers;

                //ucPlayerDetails.RefreshPlayerDetails();
                //ucPlayersList.DisplayPlayersList();


                //playersControl.lbOtherPlayers.Items.Clear();
                //playersControl.lbFavoritePlayers.Items.Clear();
                //DisplayPlayersListByFavorite();
                //ChangeFavoriteText();
                ucTeamSelect.Enabled = true;
                UseWaitCursor = false;
            }
        }
    }
}
