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
        private bool sortAscending = false;

        public MainForm()
        {
            _teams = new List<Team>();
            _favoriteTeam = new Team();
            _currentPlayers = new List<Player>();
            _selected = new List<Player>();
            _currentTeam = new Team();
            _matches = new List<Match>();
            _playersStatistic = new List<PlayerStatistic>();

            InitializeComponent();
            dgPlayers.Visible = false;
            dgMatches.Visible = false;
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
            _matches = Repository.GetMatchesForSelectedTeam();
            _playersStatistic = Repository.GetPlayerStatisticsForSelectedTeam();
            UseWaitCursor = false;
            Enabled = true;
            tbRang.Refresh();
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

            string playerName =resFolder +  "players\\img\\" + $"{pd.Name.Replace(" ", "")}.jpg";

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
            //if ((sender as RadioButton).Text == "Players")
            //{
            //    dgMatches.Visible = false;
            //    dgPlayers.Visible = true;
            //}
            //else if ((sender as RadioButton).Text == "Matches")
            //{
            //    dgMatches.Visible = true;
            //    dgPlayers.Visible = false;
            //}

        }

        private void RbPlayers_CheckedChanged(object sender, EventArgs e)
        {
            dgMatches.Visible = false;
            dgPlayers.Visible = true;

            bindSourcePlayers.DataSource = _playersStatistic;
            dgPlayers.DataSource = bindSourcePlayers;
            dgPlayers.DataSource = _playersStatistic.OrderBy(dgPlayers.Columns["Goals"].DataPropertyName).Reverse().ToList();

            dgPlayers.AutoGenerateColumns = false;
            dgPlayers.RowTemplate.Height = 80;

            dgPlayers.Columns["Name"].Visible = true;
            dgPlayers.Columns["Name"].DisplayIndex = 0;
            dgPlayers.Columns["Name"].Width = 180;
            dgPlayers.Columns["Appearances"].DisplayIndex = 1;
            dgPlayers.Columns["Appearances"].Width = 110;
            dgPlayers.Columns["Yellow_cards"].DisplayIndex = 2;
            dgPlayers.Columns["Yellow_cards"].Width = 110;
            dgPlayers.Columns["Goals"].DisplayIndex = 3;
            dgPlayers.Columns["Goals"].Width = 80;
            dgPlayers.Columns["Image"].DisplayIndex = 4;
            dgPlayers.Columns["Image"].Width = 190;

            dgPlayers.Columns["Captain"].Visible = false;
            dgPlayers.Columns["Favorite"].Visible = false;
            dgPlayers.Columns["Position"].Visible = false;
            dgPlayers.Columns["Shirt_number"].Visible = false;

            this.dgPlayers.RowTemplate.DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgPlayers.DefaultCellStyle.NullValue = "N/A";
            this.dgPlayers.DefaultCellStyle.WrapMode =
                DataGridViewTriState.True;
        }
        private void RbMatches_CheckedChanged(object sender, EventArgs e)
        {
            dgMatches.Visible = true;
            dgPlayers.Visible = false;

            bindSourceMatches.DataSource = _matches;
            dgMatches.DataSource = bindSourceMatches;
            dgMatches.DataSource = _matches.OrderBy(dgMatches.Columns["Attendance"].DataPropertyName).Reverse().ToList();

            dgMatches.AutoGenerateColumns = false;
            //dgMatches.RowTemplate.Height = 38;

            dgMatches.Columns["Datetime"].DisplayIndex = 0;
            dgMatches.Columns["Datetime"].HeaderText = "Date";
            dgMatches.Columns["Datetime"].Width = 100;
            dgMatches.Columns["Home_team_country"].HeaderText = "Home team";
            dgMatches.Columns["Home_team_country"].DisplayIndex = 1;
            dgMatches.Columns["Home_team_country"].Width = 90;
            dgMatches.Columns["Away_team_country"].HeaderText = "Away team";
            dgMatches.Columns["Away_team_country"].DisplayIndex = 2;
            dgMatches.Columns["Away_team_country"].Width = 90;
            dgMatches.Columns["Location"].DisplayIndex = 3;
            dgMatches.Columns["Location"].Width = 80;
            dgMatches.Columns["Venue"].DisplayIndex = 4;
            dgMatches.Columns["Venue"].Width = 180;
            dgMatches.Columns["Winner"].DisplayIndex = 5;
            dgMatches.Columns["Winner"].Width = 100;
            dgMatches.Columns["Attendance"].DisplayIndex = 6;
            dgMatches.Columns["Attendance"].Width = 100;

            //dgMatches.Columns["Venue"].Visible = false;

            this.dgMatches.RowTemplate.DefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgMatches.DefaultCellStyle.NullValue = "N/A";
            this.dgMatches.DefaultCellStyle.WrapMode =
                DataGridViewTriState.True;
        }

        private void DgMatches_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (sortAscending)
                dgMatches.DataSource = _matches.OrderBy(dgMatches.Columns[e.ColumnIndex].DataPropertyName).ToList();
            else
                dgMatches.DataSource = _matches.OrderBy(dgMatches.Columns[e.ColumnIndex].DataPropertyName).Reverse().ToList();
            sortAscending = !sortAscending;
        }
        private void DgPlayers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != 0 && e.ColumnIndex != 2) return;

            if (sortAscending)
                dgPlayers.DataSource = _playersStatistic.OrderBy(dgPlayers.Columns[e.ColumnIndex].DataPropertyName).ToList();
            else
                dgPlayers.DataSource = _playersStatistic.OrderBy(dgPlayers.Columns[e.ColumnIndex].DataPropertyName).Reverse().ToList();
            sortAscending = !sortAscending;
        }
        //Printing 

        StringFormat strFormat; //Used to format the grid rows.
        ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        int iCellHeight = 30; //Used to get/set the datagridview cell height
        int iTotalWidth = 0; //
        int iRow = 0;//Used as counter
        bool bFirstPage = false; //Used to check whether we are printing first page
        bool bNewPage = false;// Used to check whether we are printing a new page
        int iHeaderHeight = 0; //Used for the header height

        private void PrintDocumentPlayers_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            try
            {
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dgPlayers.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                            (double)iTotalWidth * (double)iTotalWidth *
                            ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                            GridCol.InheritedStyle.Font, iTmpWidth).Height) + 21;

                        // Save width and height of headers
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= dgPlayers.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dgPlayers.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 45;
                    int iCount = 0;
                    //Check whether the current page settings allows more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            e.Graphics.DrawString("Customer Summary",
                                new Font(dgPlayers.Font, FontStyle.Bold),
                                Brushes.Black, e.MarginBounds.Left,
                                e.MarginBounds.Top - e.Graphics.MeasureString("Customer Summary",
                                new Font(dgPlayers.Font, FontStyle.Bold),
                                e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " +
                                DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString(strDate,
                                new Font(dgPlayers.Font, FontStyle.Bold), Brushes.Black,
                                e.MarginBounds.Left +
                                (e.MarginBounds.Width - e.Graphics.MeasureString(strDate,
                                new Font(dgPlayers.Font, FontStyle.Bold),
                                e.MarginBounds.Width).Width),
                                e.MarginBounds.Top - e.Graphics.MeasureString("Customer Summary",
                                new Font(new Font(dgPlayers.Font, FontStyle.Bold),
                                FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dgPlayers.Columns)
                            {
                                if (GridCol.HeaderText == "Favorite") continue;
                                

                                
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.ColumnIndex == 8) continue;
                            
                            if (Cel.ColumnIndex == 7)
                            {
                                Image pic = new Bitmap(_currentPlayers[0].Image);
                                e.Graphics.DrawImage(pic, new RectangleF((int)arrColumnLefts[iCount],
                                    (float)iTopMargin,
                                    (int)arrColumnWidths[iCount], (float)iCellHeight));
                            }
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(),
                                    Cel.InheritedStyle.Font,
                                    new SolidBrush(Cel.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount],
                                    (float)iTopMargin,
                                    (int)arrColumnWidths[iCount], (float)iCellHeight),
                                    strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black,
                                new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                (int)arrColumnWidths[iCount], iCellHeight));
                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }
                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
        }
        private void PrintDocumentPlayers_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dgPlayers.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog.ShowDialog();
        }


    }
}
