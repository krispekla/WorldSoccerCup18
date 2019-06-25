namespace WINForms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbFav = new System.Windows.Forms.Label();
            this.lbPl = new System.Windows.Forms.Label();
            this.lbSelectedTeam = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.flFavoritePlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.flAllPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.backgroundWorkerInit = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSaveFavoriteTeam = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerGetPlayersByCode = new System.ComponentModel.BackgroundWorker();
            this.cmPlayersAll = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmItemToFavorites = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmPlayersFav = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorkerSaveFavoritePlayers = new System.ComponentModel.BackgroundWorker();
            this.ucTeamSelect = new WINForms.Controls.TeamSelect();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.cmPlayersAll.SuspendLayout();
            this.cmPlayersFav.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbFav
            // 
            this.lbFav.AutoSize = true;
            this.lbFav.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFav.Location = new System.Drawing.Point(203, 47);
            this.lbFav.Name = "lbFav";
            this.lbFav.Size = new System.Drawing.Size(109, 17);
            this.lbFav.TabIndex = 4;
            this.lbFav.Text = "Favorite players";
            // 
            // lbPl
            // 
            this.lbPl.AutoSize = true;
            this.lbPl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPl.Location = new System.Drawing.Point(837, 47);
            this.lbPl.Name = "lbPl";
            this.lbPl.Size = new System.Drawing.Size(23, 17);
            this.lbPl.TabIndex = 5;
            this.lbPl.Text = "All";
            // 
            // lbSelectedTeam
            // 
            this.lbSelectedTeam.AutoSize = true;
            this.lbSelectedTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSelectedTeam.Location = new System.Drawing.Point(527, 26);
            this.lbSelectedTeam.Name = "lbSelectedTeam";
            this.lbSelectedTeam.Size = new System.Drawing.Size(15, 20);
            this.lbSelectedTeam.TabIndex = 6;
            this.lbSelectedTeam.Text = "-";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(88, 113);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1120, 612);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flFavoritePlayers);
            this.tabPage1.Controls.Add(this.flAllPlayers);
            this.tabPage1.Controls.Add(this.lbSelectedTeam);
            this.tabPage1.Controls.Add(this.lbFav);
            this.tabPage1.Controls.Add(this.lbPl);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1112, 581);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Players";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // flFavoritePlayers
            // 
            this.flFavoritePlayers.AutoScroll = true;
            this.flFavoritePlayers.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flFavoritePlayers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flFavoritePlayers.Location = new System.Drawing.Point(24, 83);
            this.flFavoritePlayers.Name = "flFavoritePlayers";
            this.flFavoritePlayers.Size = new System.Drawing.Size(509, 467);
            this.flFavoritePlayers.TabIndex = 8;
            // 
            // flAllPlayers
            // 
            this.flAllPlayers.AutoScroll = true;
            this.flAllPlayers.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flAllPlayers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flAllPlayers.Location = new System.Drawing.Point(586, 83);
            this.flAllPlayers.Name = "flAllPlayers";
            this.flAllPlayers.Size = new System.Drawing.Size(505, 467);
            this.flAllPlayers.TabIndex = 7;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1112, 581);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Rang lists";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // backgroundWorkerInit
            // 
            this.backgroundWorkerInit.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerInit_DoWork);
            this.backgroundWorkerInit.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerInit_RunWorkerCompleted);
            // 
            // backgroundWorkerSaveFavoriteTeam
            // 
            this.backgroundWorkerSaveFavoriteTeam.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerSaveFavoriteTeam_DoWork);
            this.backgroundWorkerSaveFavoriteTeam.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerSaveFavoriteTeam_RunWorkerCompleted);
            // 
            // backgroundWorkerGetPlayersByCode
            // 
            this.backgroundWorkerGetPlayersByCode.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerGetPlayersByCode_DoWork);
            this.backgroundWorkerGetPlayersByCode.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerGetPlayersByCode_RunWorkerCompleted);
            // 
            // cmPlayersAll
            // 
            this.cmPlayersAll.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmItemToFavorites,
            this.removeAllToolStripMenuItem1});
            this.cmPlayersAll.Name = "cmPlayers";
            this.cmPlayersAll.Size = new System.Drawing.Size(167, 48);
            this.cmPlayersAll.Opened += new System.EventHandler(this.CmPlayers_Opened);
            // 
            // cmItemToFavorites
            // 
            this.cmItemToFavorites.Name = "cmItemToFavorites";
            this.cmItemToFavorites.Size = new System.Drawing.Size(166, 22);
            this.cmItemToFavorites.Text = "Move to favorites";
            this.cmItemToFavorites.Click += new System.EventHandler(this.CmChangeToFavorites_Click);
            // 
            // removeAllToolStripMenuItem1
            // 
            this.removeAllToolStripMenuItem1.Name = "removeAllToolStripMenuItem1";
            this.removeAllToolStripMenuItem1.Size = new System.Drawing.Size(166, 22);
            this.removeAllToolStripMenuItem1.Text = "Remove All";
            this.removeAllToolStripMenuItem1.Click += new System.EventHandler(this.RemoveAllFromFavorites);
            // 
            // cmPlayersFav
            // 
            this.cmPlayersFav.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveToolStripMenuItem,
            this.removeAllToolStripMenuItem});
            this.cmPlayersFav.Name = "cmPlayersFav";
            this.cmPlayersFav.Size = new System.Drawing.Size(197, 48);
            this.cmPlayersFav.Opened += new System.EventHandler(this.CmPlayers_Opened);
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.moveToolStripMenuItem.Text = "Remove from Favorites";
            this.moveToolStripMenuItem.Click += new System.EventHandler(this.CmRemoveFromFavoritesClick);
            // 
            // removeAllToolStripMenuItem
            // 
            this.removeAllToolStripMenuItem.Name = "removeAllToolStripMenuItem";
            this.removeAllToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.removeAllToolStripMenuItem.Text = "Remove All";
            this.removeAllToolStripMenuItem.Click += new System.EventHandler(this.RemoveAllFromFavorites);
            // 
            // backgroundWorkerSaveFavoritePlayers
            // 
            this.backgroundWorkerSaveFavoritePlayers.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerSaveFavoritePlayers_DoWork);
            this.backgroundWorkerSaveFavoritePlayers.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerSaveFavoritePlayers_RunWorkerCompleted);
            // 
            // ucTeamSelect
            // 
            this.ucTeamSelect.Location = new System.Drawing.Point(405, 32);
            this.ucTeamSelect.Name = "ucTeamSelect";
            this.ucTeamSelect.Size = new System.Drawing.Size(513, 55);
            this.ucTeamSelect.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1295, 737);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ucTeamSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.cmPlayersAll.ResumeLayout(false);
            this.cmPlayersFav.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.TeamSelect ucTeamSelect;
        private System.Windows.Forms.Label lbFav;
        private System.Windows.Forms.Label lbPl;
        private System.Windows.Forms.Label lbSelectedTeam;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.FlowLayoutPanel flFavoritePlayers;
        private System.Windows.Forms.FlowLayoutPanel flAllPlayers;
        private System.Windows.Forms.TabPage tabPage2;
        private System.ComponentModel.BackgroundWorker backgroundWorkerInit;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSaveFavoriteTeam;
        private System.ComponentModel.BackgroundWorker backgroundWorkerGetPlayersByCode;
        private System.Windows.Forms.ContextMenuStrip cmPlayersAll;
        private System.Windows.Forms.ToolStripMenuItem cmItemToFavorites;
        private System.Windows.Forms.ContextMenuStrip cmPlayersFav;
        private System.Windows.Forms.ToolStripMenuItem removeAllToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAllToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSaveFavoritePlayers;
    }
}