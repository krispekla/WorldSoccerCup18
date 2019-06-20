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

namespace WINForms
{
    public partial class MainForm : Form
    {
        private List<Team> teams;
        private Team favoriteTeam;
        private List<Player> currentPlayers;
        public MainForm()
        {
            teams = new List<Team>();
            favoriteTeam = new Team();
            currentPlayers = new List<Player>();

            InitializeComponent();
            bckWorkerGetTeams.RunWorkerAsync();

            playersControl.ListBoxOthersDoubleClick += PlayersControl_ListBoxClick;
            playersControl.ListBoxFavoritesDoubleClick += PlayersControl_ListBoxFavoritesDoubleClick;
            ccPlayerDetails.ComboBoxSelectedPlayerDetailsSelectedValueChanged += CcPlayerDetails_ComboBoxSelectedPlayerDetailsSelectedValueChanged;
            ccPlayerDetails.ButtonDetailsChangePictureClick += CcPlayerDetails_ButtonDetailsChangePictureClick;
        }

        private void CcPlayerDetails_ButtonDetailsChangePictureClick(object sender, EventArgs e)
        {
            string rootPath = Application.StartupPath;
            Directory.CreateDirectory(rootPath + @"\players\img\");

            string playerName = @"players\img\" + $"{ccPlayerDetails.lbDetailsName.Text.Replace(" ", "")}.jpg";

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Change picture";
            saveFileDialog.CheckFileExists = true;
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.DefaultExt = "jpeg";
            saveFileDialog.Filter = "Pictures|*.bmp;*.jpg;*.jpeg;*.png;|All|*.*";
            saveFileDialog.CreatePrompt = false;
            saveFileDialog.OverwritePrompt = false;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Repository.ChangePlayerPicture(saveFileDialog.FileName, playerName);
                currentPlayers.Find(v => v.Name == ccPlayerDetails.cbSelectedPlayerDetails.Text).Image = saveFileDialog.FileName;

                RefreshPlayerDetailsComboBox();
            }
        }

        private void RefreshPlayerDetailsComboBox()
        {
            int rememberIndex = ccPlayerDetails.cbSelectedPlayerDetails.SelectedIndex;
            ccPlayerDetails.cbSelectedPlayerDetails.Items.Clear();
            foreach (Player cp in currentPlayers)
            {
                ccPlayerDetails.cbSelectedPlayerDetails.Items.Add(cp);
            }
            ccPlayerDetails.cbSelectedPlayerDetails.DisplayMember = "Name";

            if (rememberIndex <= 0)
                ccPlayerDetails.cbSelectedPlayerDetails.SelectedIndex = 0;
            else
                ccPlayerDetails.cbSelectedPlayerDetails.SelectedIndex = rememberIndex;

            ccPlayerDetails.cbSelectedPlayerDetails.Refresh();
        }

        private void CcPlayerDetails_ComboBoxSelectedPlayerDetailsSelectedValueChanged(object sender, EventArgs e)
        {
            ccPlayerDetails.ShowPlayerDetails(currentPlayers.Find(pl => pl.Name == ccPlayerDetails.cbSelectedPlayerDetails.Text));
        }

        private void bckWorkerGetTeams_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = Repository.GetTeams().Result;
        }

        private void bckWorkerGetTeams_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                //Mapping returned values
                teams = (List<Team>)e.Result;
                foreach (Team t in teams)
                {
                    cbFavoriteTeams.Items.Add(string.Format("{0} {1}", t.Country, t.Fifa_code));
                }

                //Favorite set
                string favoriteTeam = Repository.GetFavoriteTeam();

                if (favoriteTeam != null)
                {
                    SetFavorite(favoriteTeam);
                }
            }
        }

        private void SetFavorite(string favorite)
        {
            favoriteTeam = teams.Find(y => y.TeamName() == favorite);
            cbFavoriteTeams.SelectedItem = favoriteTeam.TeamName();
            ChangeFavoriteText();

        }

        private void PlayersControl_ListBoxFavoritesDoubleClick(object sender, EventArgs e)
        {

            ToggleFavoriteStatus(true);

            DisplayPlayersListByFavorite();
            playersControl.Refresh();

        }

        private void ToggleFavoriteStatus(bool fromFavorites)
        {
            if (fromFavorites)
                currentPlayers.Find(match: x => x.Name == playersControl.lbFavoritePlayers.SelectedItem.ToString()).Favorite = !(currentPlayers.Find(match: x => x.Name == playersControl.lbFavoritePlayers.SelectedItem.ToString()).Favorite);
            else
                currentPlayers.Find(match: x => x.Name == playersControl.lbOtherPlayers.SelectedItem.ToString()).Favorite = !(currentPlayers.Find(match: x => x.Name == playersControl.lbOtherPlayers.SelectedItem.ToString()).Favorite);

        }

        private void PlayersControl_ListBoxClick(object sender, EventArgs e)
        {
            if (playersControl.lbFavoritePlayers.Items.Count == 3)
            {
                throw new Exception("Can't have more than 3 favorite players, please remove one first.");
            }
            ToggleFavoriteStatus(false);

            DisplayPlayersListByFavorite();
            playersControl.Refresh();
        }



        private void ChangeFavoriteText()
        {
            if (cbFavoriteTeams.SelectedIndex == -1)
            {
                lbFavorite.Text = "Set favorite team:";
            }
            else
            {
                lbFavorite.Text = "Favorite team:";
            }
        }

        private void BtnSetFavorite_Click(object sender, EventArgs e)
        {
            Repository.SaveFavoriteTeam(cbFavoriteTeams.SelectedItem.ToString());
            String fifa_code = parseFifaCode(cbFavoriteTeams.SelectedItem.ToString());
            bckWorkerGetPlayersByCode.RunWorkerAsync(fifa_code);
        }

        private void BckWorkerGetPlayersByCode_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = Repository.GetPlayersByCodeAsync((String)e.Argument).Result;

        }

        private void BckWorkerGetPlayersByCode_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                currentPlayers = (List<Player>)e.Result;

                RefreshPlayerDetailsComboBox();


                playersControl.lbOtherPlayers.Items.Clear();
                playersControl.lbFavoritePlayers.Items.Clear();
                DisplayPlayersListByFavorite();
                ChangeFavoriteText();
            }
        }


        private void DisplayPlayersListByFavorite()
        {
            playersControl.lbOtherPlayers.Items.Clear();
            playersControl.lbFavoritePlayers.Items.Clear();
            playersControl.lbOtherPlayers.DataSource = null;
            playersControl.lbFavoritePlayers.DataSource = null;
            foreach (Player p in currentPlayers)
            {
                if (p.Favorite)
                    playersControl.lbFavoritePlayers.Items.Add(p.Name);
                else
                    playersControl.lbOtherPlayers.Items.Add(p.Name);
            }
        }

        private string parseFifaCode(string v)
        {
            string[] details = v.Split();
            return details[details.Length - 1];
        }
    }
}
