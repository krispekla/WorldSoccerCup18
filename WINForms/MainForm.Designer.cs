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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            this.printDocumentPlayers = new System.Drawing.Printing.PrintDocument();
            this.printDocumentMatches = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.bindSourcePlayers = new System.Windows.Forms.BindingSource(this.components);
            this.bindSourceMatches = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbMatches = new System.Windows.Forms.Label();
            this.btnPrintMatches = new System.Windows.Forms.Button();
            this.btnRefreshMatches = new System.Windows.Forms.Button();
            this.dgRangsMatches = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbPlayers = new System.Windows.Forms.Label();
            this.btnRangPlayersPrint = new System.Windows.Forms.Button();
            this.btnRangPlayers = new System.Windows.Forms.Button();
            this.dgRangPlayers = new System.Windows.Forms.DataGridView();
            this.tbPlayers = new System.Windows.Forms.TabPage();
            this.flFavoritePlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.flAllPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.lbSelectedTeam = new System.Windows.Forms.Label();
            this.lbFav = new System.Windows.Forms.Label();
            this.lbPl = new System.Windows.Forms.Label();
            this.tb = new System.Windows.Forms.TabControl();
            this.ucTeamSelect = new WINForms.Controls.TeamSelect();
            this.cmPlayersAll.SuspendLayout();
            this.cmPlayersFav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindSourcePlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindSourceMatches)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRangsMatches)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRangPlayers)).BeginInit();
            this.tbPlayers.SuspendLayout();
            this.tb.SuspendLayout();
            this.SuspendLayout();
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
            resources.ApplyResources(this.cmPlayersAll, "cmPlayersAll");
            this.cmPlayersAll.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmPlayersAll.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmItemToFavorites,
            this.removeAllToolStripMenuItem1});
            this.cmPlayersAll.Name = "cmPlayers";
            this.cmPlayersAll.Opened += new System.EventHandler(this.CmPlayers_Opened);
            // 
            // cmItemToFavorites
            // 
            resources.ApplyResources(this.cmItemToFavorites, "cmItemToFavorites");
            this.cmItemToFavorites.Name = "cmItemToFavorites";
            this.cmItemToFavorites.Click += new System.EventHandler(this.CmChangeToFavorites_Click);
            // 
            // removeAllToolStripMenuItem1
            // 
            resources.ApplyResources(this.removeAllToolStripMenuItem1, "removeAllToolStripMenuItem1");
            this.removeAllToolStripMenuItem1.Name = "removeAllToolStripMenuItem1";
            this.removeAllToolStripMenuItem1.Click += new System.EventHandler(this.RemoveAllFromFavorites);
            // 
            // cmPlayersFav
            // 
            resources.ApplyResources(this.cmPlayersFav, "cmPlayersFav");
            this.cmPlayersFav.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmPlayersFav.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveToolStripMenuItem,
            this.removeAllToolStripMenuItem});
            this.cmPlayersFav.Name = "cmPlayersFav";
            this.cmPlayersFav.Opened += new System.EventHandler(this.CmPlayers_Opened);
            // 
            // moveToolStripMenuItem
            // 
            resources.ApplyResources(this.moveToolStripMenuItem, "moveToolStripMenuItem");
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Click += new System.EventHandler(this.CmRemoveFromFavoritesClick);
            // 
            // removeAllToolStripMenuItem
            // 
            resources.ApplyResources(this.removeAllToolStripMenuItem, "removeAllToolStripMenuItem");
            this.removeAllToolStripMenuItem.Name = "removeAllToolStripMenuItem";
            this.removeAllToolStripMenuItem.Click += new System.EventHandler(this.RemoveAllFromFavorites);
            // 
            // backgroundWorkerSaveFavoritePlayers
            // 
            this.backgroundWorkerSaveFavoritePlayers.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerSaveFavoritePlayers_DoWork);
            this.backgroundWorkerSaveFavoritePlayers.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerSaveFavoritePlayers_RunWorkerCompleted);
            // 
            // printPreviewDialog
            // 
            resources.ApplyResources(this.printPreviewDialog, "printPreviewDialog");
            this.printPreviewDialog.Document = this.printDocumentPlayers;
            this.printPreviewDialog.Name = "printPreviewDialog";
            // 
            // btnSettings
            // 
            resources.ApplyResources(this.btnSettings, "btnSettings");
            this.btnSettings.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettingsClick);
            // 
            // btnExit
            // 
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Name = "btnExit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExitClick);
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Controls.Add(this.lbMatches);
            this.tabPage2.Controls.Add(this.btnPrintMatches);
            this.tabPage2.Controls.Add(this.btnRefreshMatches);
            this.tabPage2.Controls.Add(this.dgRangsMatches);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbMatches
            // 
            resources.ApplyResources(this.lbMatches, "lbMatches");
            this.lbMatches.Name = "lbMatches";
            // 
            // btnPrintMatches
            // 
            resources.ApplyResources(this.btnPrintMatches, "btnPrintMatches");
            this.btnPrintMatches.Name = "btnPrintMatches";
            this.btnPrintMatches.UseVisualStyleBackColor = true;
            this.btnPrintMatches.Click += new System.EventHandler(this.btnPrintMatches_Click);
            // 
            // btnRefreshMatches
            // 
            resources.ApplyResources(this.btnRefreshMatches, "btnRefreshMatches");
            this.btnRefreshMatches.Name = "btnRefreshMatches";
            this.btnRefreshMatches.UseVisualStyleBackColor = true;
            this.btnRefreshMatches.Click += new System.EventHandler(this.btnRefreshMatches_Click);
            // 
            // dgRangsMatches
            // 
            resources.ApplyResources(this.dgRangsMatches, "dgRangsMatches");
            this.dgRangsMatches.AllowUserToAddRows = false;
            this.dgRangsMatches.AllowUserToDeleteRows = false;
            this.dgRangsMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRangsMatches.Name = "dgRangsMatches";
            this.dgRangsMatches.ReadOnly = true;
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.lbPlayers);
            this.tabPage1.Controls.Add(this.btnRangPlayersPrint);
            this.tabPage1.Controls.Add(this.btnRangPlayers);
            this.tabPage1.Controls.Add(this.dgRangPlayers);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbPlayers
            // 
            resources.ApplyResources(this.lbPlayers, "lbPlayers");
            this.lbPlayers.Name = "lbPlayers";
            // 
            // btnRangPlayersPrint
            // 
            resources.ApplyResources(this.btnRangPlayersPrint, "btnRangPlayersPrint");
            this.btnRangPlayersPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRangPlayersPrint.Name = "btnRangPlayersPrint";
            this.btnRangPlayersPrint.UseVisualStyleBackColor = true;
            this.btnRangPlayersPrint.Click += new System.EventHandler(this.btnRangPlayersPrintClick);
            // 
            // btnRangPlayers
            // 
            resources.ApplyResources(this.btnRangPlayers, "btnRangPlayers");
            this.btnRangPlayers.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRangPlayers.Name = "btnRangPlayers";
            this.btnRangPlayers.UseVisualStyleBackColor = true;
            this.btnRangPlayers.Click += new System.EventHandler(this.btnRangPlayersClick);
            // 
            // dgRangPlayers
            // 
            resources.ApplyResources(this.dgRangPlayers, "dgRangPlayers");
            this.dgRangPlayers.AllowUserToAddRows = false;
            this.dgRangPlayers.AllowUserToDeleteRows = false;
            this.dgRangPlayers.AllowUserToOrderColumns = true;
            this.dgRangPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRangPlayers.Name = "dgRangPlayers";
            this.dgRangPlayers.ReadOnly = true;
            // 
            // tbPlayers
            // 
            resources.ApplyResources(this.tbPlayers, "tbPlayers");
            this.tbPlayers.Controls.Add(this.flFavoritePlayers);
            this.tbPlayers.Controls.Add(this.flAllPlayers);
            this.tbPlayers.Controls.Add(this.lbSelectedTeam);
            this.tbPlayers.Controls.Add(this.lbFav);
            this.tbPlayers.Controls.Add(this.lbPl);
            this.tbPlayers.Name = "tbPlayers";
            this.tbPlayers.UseVisualStyleBackColor = true;
            // 
            // flFavoritePlayers
            // 
            resources.ApplyResources(this.flFavoritePlayers, "flFavoritePlayers");
            this.flFavoritePlayers.AllowDrop = true;
            this.flFavoritePlayers.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flFavoritePlayers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flFavoritePlayers.Name = "flFavoritePlayers";
            this.flFavoritePlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.flFavoritePlayers_DragDrop);
            this.flFavoritePlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.flFavoritePlayers_DragEnterIntoFavorite);
            // 
            // flAllPlayers
            // 
            resources.ApplyResources(this.flAllPlayers, "flAllPlayers");
            this.flAllPlayers.AllowDrop = true;
            this.flAllPlayers.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flAllPlayers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flAllPlayers.Name = "flAllPlayers";
            // 
            // lbSelectedTeam
            // 
            resources.ApplyResources(this.lbSelectedTeam, "lbSelectedTeam");
            this.lbSelectedTeam.Name = "lbSelectedTeam";
            // 
            // lbFav
            // 
            resources.ApplyResources(this.lbFav, "lbFav");
            this.lbFav.Name = "lbFav";
            // 
            // lbPl
            // 
            resources.ApplyResources(this.lbPl, "lbPl");
            this.lbPl.Name = "lbPl";
            // 
            // tb
            // 
            resources.ApplyResources(this.tb, "tb");
            this.tb.Controls.Add(this.tbPlayers);
            this.tb.Controls.Add(this.tabPage1);
            this.tb.Controls.Add(this.tabPage2);
            this.tb.Name = "tb";
            this.tb.SelectedIndex = 0;
            this.tb.SelectedIndexChanged += new System.EventHandler(this.Tb_SelectedIndexChanged);
            // 
            // ucTeamSelect
            // 
            resources.ApplyResources(this.ucTeamSelect, "ucTeamSelect");
            this.ucTeamSelect.Name = "ucTeamSelect";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnExit;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.tb);
            this.Controls.Add(this.ucTeamSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.cmPlayersAll.ResumeLayout(false);
            this.cmPlayersFav.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindSourcePlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindSourceMatches)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRangsMatches)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRangPlayers)).EndInit();
            this.tbPlayers.ResumeLayout(false);
            this.tbPlayers.PerformLayout();
            this.tb.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.TeamSelect ucTeamSelect;
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
        private System.Windows.Forms.BindingSource bindSourcePlayers;
        private System.Windows.Forms.BindingSource bindSourceMatches;
        private System.Drawing.Printing.PrintDocument printDocumentPlayers;
        private System.Drawing.Printing.PrintDocument printDocumentMatches;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnPrintMatches;
        private System.Windows.Forms.Button btnRefreshMatches;
        private System.Windows.Forms.DataGridView dgRangsMatches;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lbPlayers;
        private System.Windows.Forms.Button btnRangPlayersPrint;
        private System.Windows.Forms.Button btnRangPlayers;
        private System.Windows.Forms.DataGridView dgRangPlayers;
        private System.Windows.Forms.TabPage tbPlayers;
        private System.Windows.Forms.FlowLayoutPanel flFavoritePlayers;
        private System.Windows.Forms.FlowLayoutPanel flAllPlayers;
        private System.Windows.Forms.Label lbSelectedTeam;
        private System.Windows.Forms.Label lbFav;
        private System.Windows.Forms.Label lbPl;
        private System.Windows.Forms.TabControl tb;
        private System.Windows.Forms.Label lbMatches;
    }
}