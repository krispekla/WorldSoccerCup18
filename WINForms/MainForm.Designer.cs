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
            this.lbFav = new System.Windows.Forms.Label();
            this.lbPl = new System.Windows.Forms.Label();
            this.lbSelectedTeam = new System.Windows.Forms.Label();
            this.tb = new System.Windows.Forms.TabControl();
            this.tbPlayers = new System.Windows.Forms.TabPage();
            this.flFavoritePlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.flAllPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.tbRang = new System.Windows.Forms.TabPage();
            this.dgMatches = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgPlayers = new System.Windows.Forms.DataGridView();
            this.rbMatches = new System.Windows.Forms.RadioButton();
            this.rbPlayers = new System.Windows.Forms.RadioButton();
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
            this.bindSourcePlayers = new System.Windows.Forms.BindingSource(this.components);
            this.bindSourceMatches = new System.Windows.Forms.BindingSource(this.components);
            this.ucTeamSelect = new WINForms.Controls.TeamSelect();
            this.printDocumentPlayers = new System.Drawing.Printing.PrintDocument();
            this.printDocumentMatches = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.tb.SuspendLayout();
            this.tbPlayers.SuspendLayout();
            this.tbRang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMatches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlayers)).BeginInit();
            this.cmPlayersAll.SuspendLayout();
            this.cmPlayersFav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindSourcePlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindSourceMatches)).BeginInit();
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
            // tb
            // 
            this.tb.Controls.Add(this.tbPlayers);
            this.tb.Controls.Add(this.tbRang);
            this.tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb.Location = new System.Drawing.Point(88, 113);
            this.tb.Name = "tb";
            this.tb.SelectedIndex = 0;
            this.tb.Size = new System.Drawing.Size(1120, 568);
            this.tb.TabIndex = 7;
            this.tb.SelectedIndexChanged += new System.EventHandler(this.Tb_SelectedIndexChanged);
            this.tb.Click += new System.EventHandler(this.RbPlayers_CheckedChanged);
            // 
            // tbPlayers
            // 
            this.tbPlayers.Controls.Add(this.flFavoritePlayers);
            this.tbPlayers.Controls.Add(this.flAllPlayers);
            this.tbPlayers.Controls.Add(this.lbSelectedTeam);
            this.tbPlayers.Controls.Add(this.lbFav);
            this.tbPlayers.Controls.Add(this.lbPl);
            this.tbPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPlayers.Location = new System.Drawing.Point(4, 27);
            this.tbPlayers.Name = "tbPlayers";
            this.tbPlayers.Padding = new System.Windows.Forms.Padding(3);
            this.tbPlayers.Size = new System.Drawing.Size(1112, 537);
            this.tbPlayers.TabIndex = 0;
            this.tbPlayers.Text = "Players";
            this.tbPlayers.UseVisualStyleBackColor = true;
            // 
            // flFavoritePlayers
            // 
            this.flFavoritePlayers.AutoScroll = true;
            this.flFavoritePlayers.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flFavoritePlayers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flFavoritePlayers.Location = new System.Drawing.Point(24, 83);
            this.flFavoritePlayers.Name = "flFavoritePlayers";
            this.flFavoritePlayers.Size = new System.Drawing.Size(509, 377);
            this.flFavoritePlayers.TabIndex = 8;
            // 
            // flAllPlayers
            // 
            this.flAllPlayers.AutoScroll = true;
            this.flAllPlayers.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flAllPlayers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flAllPlayers.Location = new System.Drawing.Point(586, 83);
            this.flAllPlayers.Name = "flAllPlayers";
            this.flAllPlayers.Size = new System.Drawing.Size(505, 377);
            this.flAllPlayers.TabIndex = 7;
            // 
            // tbRang
            // 
            this.tbRang.Controls.Add(this.dgMatches);
            this.tbRang.Controls.Add(this.btnPrint);
            this.tbRang.Controls.Add(this.dgPlayers);
            this.tbRang.Controls.Add(this.rbMatches);
            this.tbRang.Controls.Add(this.rbPlayers);
            this.tbRang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbRang.Location = new System.Drawing.Point(4, 27);
            this.tbRang.Name = "tbRang";
            this.tbRang.Padding = new System.Windows.Forms.Padding(3);
            this.tbRang.Size = new System.Drawing.Size(1112, 537);
            this.tbRang.TabIndex = 1;
            this.tbRang.Text = "Rang lists";
            this.tbRang.UseVisualStyleBackColor = true;
            // 
            // dgMatches
            // 
            this.dgMatches.AllowUserToAddRows = false;
            this.dgMatches.AllowUserToDeleteRows = false;
            this.dgMatches.AllowUserToOrderColumns = true;
            this.dgMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMatches.Location = new System.Drawing.Point(140, 76);
            this.dgMatches.Name = "dgMatches";
            this.dgMatches.ReadOnly = true;
            this.dgMatches.Size = new System.Drawing.Size(783, 378);
            this.dgMatches.TabIndex = 5;
            this.dgMatches.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgMatches_ColumnHeaderMouseClick);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Gainsboro;
            this.btnPrint.Location = new System.Drawing.Point(934, 471);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(130, 37);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // dgPlayers
            // 
            this.dgPlayers.AllowUserToAddRows = false;
            this.dgPlayers.AllowUserToDeleteRows = false;
            this.dgPlayers.AllowUserToOrderColumns = true;
            this.dgPlayers.ColumnHeadersHeight = 42;
            this.dgPlayers.GridColor = System.Drawing.Color.Green;
            this.dgPlayers.Location = new System.Drawing.Point(166, 76);
            this.dgPlayers.Margin = new System.Windows.Forms.Padding(2);
            this.dgPlayers.Name = "dgPlayers";
            this.dgPlayers.ReadOnly = true;
            this.dgPlayers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgPlayers.RowTemplate.Height = 33;
            this.dgPlayers.Size = new System.Drawing.Size(734, 391);
            this.dgPlayers.TabIndex = 3;
            this.dgPlayers.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgPlayers_ColumnHeaderMouseClick);
            // 
            // rbMatches
            // 
            this.rbMatches.AutoSize = true;
            this.rbMatches.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbMatches.Location = new System.Drawing.Point(166, 28);
            this.rbMatches.Margin = new System.Windows.Forms.Padding(2);
            this.rbMatches.Name = "rbMatches";
            this.rbMatches.Size = new System.Drawing.Size(89, 23);
            this.rbMatches.TabIndex = 2;
            this.rbMatches.Text = "Matches";
            this.rbMatches.UseVisualStyleBackColor = true;
            this.rbMatches.CheckedChanged += new System.EventHandler(this.RbMatches_CheckedChanged);
            // 
            // rbPlayers
            // 
            this.rbPlayers.AutoSize = true;
            this.rbPlayers.Checked = true;
            this.rbPlayers.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbPlayers.Location = new System.Drawing.Point(60, 28);
            this.rbPlayers.Margin = new System.Windows.Forms.Padding(2);
            this.rbPlayers.Name = "rbPlayers";
            this.rbPlayers.Size = new System.Drawing.Size(81, 23);
            this.rbPlayers.TabIndex = 1;
            this.rbPlayers.TabStop = true;
            this.rbPlayers.Text = "Players";
            this.rbPlayers.UseVisualStyleBackColor = true;
            this.rbPlayers.CheckedChanged += new System.EventHandler(this.RbPlayers_CheckedChanged);
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
            this.cmPlayersAll.ImageScalingSize = new System.Drawing.Size(32, 32);
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
            this.cmPlayersFav.ImageScalingSize = new System.Drawing.Size(32, 32);
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
            this.ucTeamSelect.Margin = new System.Windows.Forms.Padding(6);
            this.ucTeamSelect.Name = "ucTeamSelect";
            this.ucTeamSelect.Size = new System.Drawing.Size(513, 55);
            this.ucTeamSelect.TabIndex = 1;
            // 
            // printDocumentPlayers
            // 
            this.printDocumentPlayers.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.PrintDocumentPlayers_BeginPrint);
            this.printDocumentPlayers.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocumentPlayers_PrintPage);
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Document = this.printDocumentPlayers;
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1321, 738);
            this.Controls.Add(this.tb);
            this.Controls.Add(this.ucTeamSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.tb.ResumeLayout(false);
            this.tbPlayers.ResumeLayout(false);
            this.tbPlayers.PerformLayout();
            this.tbRang.ResumeLayout(false);
            this.tbRang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMatches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlayers)).EndInit();
            this.cmPlayersAll.ResumeLayout(false);
            this.cmPlayersFav.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindSourcePlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindSourceMatches)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.TeamSelect ucTeamSelect;
        private System.Windows.Forms.Label lbFav;
        private System.Windows.Forms.Label lbPl;
        private System.Windows.Forms.Label lbSelectedTeam;
        private System.Windows.Forms.TabControl tb;
        private System.Windows.Forms.TabPage tbPlayers;
        private System.Windows.Forms.FlowLayoutPanel flFavoritePlayers;
        private System.Windows.Forms.FlowLayoutPanel flAllPlayers;
        private System.Windows.Forms.TabPage tbRang;
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
        private System.Windows.Forms.RadioButton rbMatches;
        private System.Windows.Forms.RadioButton rbPlayers;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dgPlayers;
        private System.Windows.Forms.BindingSource bindSourcePlayers;
        private System.Windows.Forms.DataGridView dgMatches;
        private System.Windows.Forms.BindingSource bindSourceMatches;
        private System.Drawing.Printing.PrintDocument printDocumentPlayers;
        private System.Drawing.Printing.PrintDocument printDocumentMatches;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
    }
}