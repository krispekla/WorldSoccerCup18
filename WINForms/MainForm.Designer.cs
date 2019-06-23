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
            this.ucTeamSelect = new WINForms.Controls.TeamSelect();
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
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucTeamSelect
            // 
            this.ucTeamSelect.Location = new System.Drawing.Point(205, 12);
            this.ucTeamSelect.Name = "ucTeamSelect";
            this.ucTeamSelect.Size = new System.Drawing.Size(521, 57);
            this.ucTeamSelect.TabIndex = 1;
            // 
            // lbFav
            // 
            this.lbFav.AutoSize = true;
            this.lbFav.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFav.Location = new System.Drawing.Point(145, 31);
            this.lbFav.Name = "lbFav";
            this.lbFav.Size = new System.Drawing.Size(109, 17);
            this.lbFav.TabIndex = 4;
            this.lbFav.Text = "Favorite players";
            // 
            // lbPl
            // 
            this.lbPl.AutoSize = true;
            this.lbPl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPl.Location = new System.Drawing.Point(624, 31);
            this.lbPl.Name = "lbPl";
            this.lbPl.Size = new System.Drawing.Size(23, 17);
            this.lbPl.TabIndex = 5;
            this.lbPl.Text = "All";
            // 
            // lbSelectedTeam
            // 
            this.lbSelectedTeam.AutoSize = true;
            this.lbSelectedTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSelectedTeam.Location = new System.Drawing.Point(416, 13);
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
            this.tabControl1.Location = new System.Drawing.Point(53, 106);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(833, 511);
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
            this.tabPage1.Size = new System.Drawing.Size(825, 480);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Players";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // flFavoritePlayers
            // 
            this.flFavoritePlayers.BackColor = System.Drawing.Color.Transparent;
            this.flFavoritePlayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flFavoritePlayers.Location = new System.Drawing.Point(28, 66);
            this.flFavoritePlayers.Name = "flFavoritePlayers";
            this.flFavoritePlayers.Size = new System.Drawing.Size(356, 408);
            this.flFavoritePlayers.TabIndex = 8;
            // 
            // flAllPlayers
            // 
            this.flAllPlayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flAllPlayers.Location = new System.Drawing.Point(445, 66);
            this.flAllPlayers.Name = "flAllPlayers";
            this.flAllPlayers.Size = new System.Drawing.Size(356, 408);
            this.flAllPlayers.TabIndex = 7;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(825, 480);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(937, 650);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ucTeamSelect);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
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
    }
}