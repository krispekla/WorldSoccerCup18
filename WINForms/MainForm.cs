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
using System.Linq.Dynamic;
using System.Collections;
using DGVPrinterHelper;
using System.Threading;

namespace WINForms
{
    public partial class MainForm : Form
    {
        private List<Team> _teams;
        private List<Player> _currentPlayers;
        private Team _currentTeam;
        private Team _favoriteTeam;
        private int _apiCallsCounter = 0;
        private int _favoritesNum = 0;
        private List<Player> _selected;
        private string _selectingFavorite = "";
        private List<Match> _matches;
        private List<PlayerStatistic> _playersStatistic;
        string resFolder;

        public MainForm()
        {
            _teams = new List<Team>();
            _favoriteTeam = new Team();
            _currentPlayers = new List<Player>();
            _selected = new List<Player>();
            _currentTeam = new Team();
            _matches = new List<Match>();
            _playersStatistic = new List<PlayerStatistic>();
            resFolder = (Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Environment.CurrentDirectory.ToString()))) + "\\resources\\");

            string lang = FileRepository.ReadLanguagePreference();
            if (lang == "English")
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("hr");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("hr");
            }

            InitializeComponent();
            ucTeamSelect.BtnSetFavoriteClick += UcTeamSelect_BtnSetFavoriteClick;
            ucTeamSelect.CbTeamsListSelectedValueChanged += UcTeamSelect_CbTeamsListSelectedValueChanged;

            backgroundWorkerInit.RunWorkerAsync();
        }

        private void UcTeamSelect_CbTeamsListSelectedValueChanged(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            ucTeamSelect.Enabled = false;
            _matches.Clear();
            _playersStatistic.Clear();
            string code = Helper.GetCountryCode((String)(ucTeamSelect.cbTeamsList.SelectedItem));
            if (!backgroundWorkerGetPlayersByCode.IsBusy)
                backgroundWorkerGetPlayersByCode.RunWorkerAsync(code);
            _currentTeam = _teams.Find(xy => xy.Fifa_code == code);
            lbSelectedTeam.Text = _currentTeam.Country;
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
            _matches.Clear();
            _playersStatistic.Clear();
            try
            {
                _playersStatistic = Repository.GetPlayerStatisticsForSelectedTeam();
                Task<List<Match>> taskMatches = Task.Run(async () => await Repository.GetMatchForSelectedTeam(_currentTeam.Fifa_code));
                _matches = taskMatches.Result;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            UseWaitCursor = false;
            Enabled = true;
            dgRangPlayers.Refresh();
            dgRangsMatches.Refresh();
        }

        private void BackgroundWorkerSaveFavoritePlayers_DoWork(object sender, DoWorkEventArgs e)
        {
            FileRepository.SaveFavoritePlayers(_currentPlayers, _currentTeam);
        }
        private void BackgroundWorkerSaveFavoritePlayers_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

        //Changing pictures
        private void Pd_PlayerDetailsChangePictureClick(object sender, EventArgs e)
        {
            Player pd = (sender as Player);
            string resFolder = (Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Environment.CurrentDirectory.ToString()))) + "\\resources\\");

            string rootPath = Application.StartupPath;
            Directory.CreateDirectory(resFolder + "players\\img\\");

            string playerName = resFolder + "players\\img\\" + $"{pd.Name.Replace(" ", "")}.jpg";

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
                FileRepository.ChangePlayerPicture(saveFileDialog.FileName, playerName);
                _currentPlayers.Find(v => v.Name == pd.Name).Image = saveFileDialog.FileName;

                LoadPlayersIntoControls();
            }
        }

        //Selecting favorite players
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
                pd.PlayerDetailsChangePictureClick += Pd_PlayerDetailsChangePictureClick;


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

        private void Pd_PlayerDetailsClickFav(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;

            PlayerDetails curr = sender as PlayerDetails;

            if (String.IsNullOrEmpty(_selectingFavorite))
                _selectingFavorite = "Fav";

            else if (_selectingFavorite != "Fav") return;


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
            UseWaitCursor = true;
            backgroundWorkerSaveFavoritePlayers.RunWorkerAsync();
        }
        private void CmRemoveFromFavoritesClick(object sender, EventArgs e)
        {
            _selectingFavorite = "";
            UpdatePlayersList();
            LoadPlayersIntoControls();
            UseWaitCursor = true;
            backgroundWorkerSaveFavoritePlayers.RunWorkerAsync();
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
            UseWaitCursor = true;
            backgroundWorkerSaveFavoritePlayers.RunWorkerAsync();
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

        private void Tb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_playersStatistic == null || _matches == null)
            {
                UseWaitCursor = true;
                Enabled = false;
            }

        }

        private void btnRangPlayersClick(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            SetupDataGridView();
            PopulateDataGridView();
            UseWaitCursor = false;
        }


        private void SetupDataGridView()
        {
            dgRangPlayers.ColumnCount = 4;

            dgRangPlayers.Name = "dgTest";
            dgRangPlayers.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgRangPlayers.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Sunken;
            dgRangPlayers.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgRangPlayers.GridColor = Color.Black;
            dgRangPlayers.RowHeadersVisible = true;

            dgRangPlayers.AutoGenerateColumns = false;
            dgRangPlayers.RowTemplate.Height = 80;

            dgRangPlayers.Columns[0].Name = "Name";
            dgRangPlayers.Columns[1].Name = "Appearances";
            dgRangPlayers.Columns[2].Name = "Yellow_cards";
            dgRangPlayers.Columns[3].Name = "Goals";

            dgRangPlayers.Columns[0].Width = 180;
            dgRangPlayers.Columns[1].Width = 110;
            dgRangPlayers.Columns[2].Width = 110;
            dgRangPlayers.Columns[3].Width = 80;

            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
            imgColumn.Name = "Image";
            imgColumn.HeaderText = "Image";
            imgColumn.Width = 150;
            dgRangPlayers.Columns.Insert(4, imgColumn);
        }

        private void PopulateDataGridView()
        {
            dgRangPlayers.Rows.Clear();
            dgRangPlayers.Rows.Add();


            foreach (PlayerStatistic item in _playersStatistic)
            {
                DataGridViewRow dg = (DataGridViewRow)dgRangPlayers.Rows[0].Clone();
                dg.Cells[0].Value = item.Name;
                dg.Cells[1].Value = item.Appearances;
                dg.Cells[2].Value = item.Yellow_cards;
                dg.Cells[3].Value = item.Goals;

                string defaultImage;
                Bitmap bmp;
                if (item.Image != null)
                {
                    defaultImage = item.Image;
                    bmp = new Bitmap(defaultImage);
                }
                else
                {
                    //defaultImage = resFolder + @"players\img\default.jpg";
                    bmp = new Bitmap(WINForms.Properties.Resources._default);
                }


                Bitmap bmpResized = new Bitmap(bmp, new Size(70, 80));

                dg.Cells[4].Value = bmpResized;
                dg.Height = 80;

                dgRangPlayers.Rows.Add(dg);
            }
            dgRangPlayers.Rows.RemoveAt(0);
        }

        private void btnRangPlayersPrintClick(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "RWA Project - World Cup 2018";
            printer.SubTitle = "Kris Peklaric";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |

    StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Algebra - 2019";
            printer.FooterSpacing = 15;

            if (DialogResult.OK == printer.DisplayPrintDialog())
            {
                printer.PrintNoDisplay(dgRangPlayers);
            }
        }

        private void btnSettingsClick(object sender, EventArgs e)
        {
            Language lang = new Language(false);
            lang.ShowDialog();
        }

        private void btnExitClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(GlobalStrings.AreYouShureClose,
                    GlobalStrings.Close, MessageBoxButtons.YesNo);


            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void btnRefreshMatches_Click(object sender, EventArgs e)
        {
            dgRangsMatches.UseWaitCursor = true;
            SetupDataGridViewMatches();
            PopulateDataGridViewMatches();
            dgRangsMatches.Refresh();
            dgRangsMatches.UseWaitCursor = false;
        }

        private void SetupDataGridViewMatches()
        {
            dgRangsMatches.ColumnCount = 7;

            dgRangsMatches.Name = "dgRangsMatches";
            dgRangsMatches.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgRangsMatches.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Sunken;
            dgRangsMatches.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgRangsMatches.GridColor = Color.Black;
            dgRangsMatches.RowHeadersVisible = true;

            dgRangsMatches.AutoGenerateColumns = false;
            dgRangsMatches.RowTemplate.Height = 80;

            dgRangsMatches.Columns[0].Name = "Date";
            dgRangsMatches.Columns[1].Name = "Home team";
            dgRangsMatches.Columns[2].Name = "Away team";
            dgRangsMatches.Columns[3].Name = "Location";
            dgRangsMatches.Columns[4].Name = "Venue";
            dgRangsMatches.Columns[5].Name = "Winner";
            dgRangsMatches.Columns[6].Name = "Attendance";

            dgRangsMatches.Columns[0].Width = 120;
            dgRangsMatches.Columns[1].Width = 90;
            dgRangsMatches.Columns[2].Width = 90;
            dgRangsMatches.Columns[3].Width = 80;
            dgRangsMatches.Columns[4].Width = 180;
            dgRangsMatches.Columns[5].Width = 100;
            dgRangsMatches.Columns[6].Width = 100;

        }

        private void PopulateDataGridViewMatches()
        {
            dgRangsMatches.Rows.Clear();
            dgRangsMatches.Rows.Add();


            foreach (Match item in _matches)
            {
                DataGridViewRow dg = (DataGridViewRow)dgRangsMatches.Rows[0].Clone();
                dg.Cells[0].Value = item.Datetime;
                dg.Cells[1].Value = item.Home_team_country;
                dg.Cells[2].Value = item.Away_team_country;
                dg.Cells[3].Value = item.Location;
                dg.Cells[4].Value = item.Venue;
                dg.Cells[5].Value = item.Winner;
                dg.Cells[6].Value = item.Attendance;

                dgRangsMatches.Rows.Add(dg);
            }
            dgRangsMatches.Rows.RemoveAt(0);
        }

        private void btnPrintMatches_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "RWA Project - World Cup 2018";
            printer.SubTitle = "Kris Peklaric";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |

    StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Algebra - 2019";
            printer.FooterSpacing = 15;

            if (DialogResult.OK == printer.DisplayPrintDialog())
            {
                printer.PrintNoDisplay(dgRangsMatches);
            }
        }
    }
}
