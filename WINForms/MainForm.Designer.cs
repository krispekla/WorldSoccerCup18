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
            this.cbFavoriteTeams = new System.Windows.Forms.ComboBox();
            this.lbFavorite = new System.Windows.Forms.Label();
            this.btnSetFavorite = new System.Windows.Forms.Button();
            this.bckWorkerGetTeams = new System.ComponentModel.BackgroundWorker();
            this.bckWorkerGetPlayersByCode = new System.ComponentModel.BackgroundWorker();
            this.ccPlayerDetails = new WINForms.Controls.PlayerDetails();
            this.playersControl = new WINForms.playersControl();
            this.SuspendLayout();
            // 
            // cbFavoriteTeams
            // 
            this.cbFavoriteTeams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFavoriteTeams.FormattingEnabled = true;
            this.cbFavoriteTeams.Location = new System.Drawing.Point(130, 15);
            this.cbFavoriteTeams.Margin = new System.Windows.Forms.Padding(2);
            this.cbFavoriteTeams.Name = "cbFavoriteTeams";
            this.cbFavoriteTeams.Size = new System.Drawing.Size(164, 21);
            this.cbFavoriteTeams.TabIndex = 3;
            // 
            // lbFavorite
            // 
            this.lbFavorite.AutoSize = true;
            this.lbFavorite.BackColor = System.Drawing.Color.Transparent;
            this.lbFavorite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFavorite.Location = new System.Drawing.Point(6, 15);
            this.lbFavorite.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbFavorite.Name = "lbFavorite";
            this.lbFavorite.Size = new System.Drawing.Size(119, 17);
            this.lbFavorite.TabIndex = 4;
            this.lbFavorite.Text = "Set favorite team:";
            // 
            // btnSetFavorite
            // 
            this.btnSetFavorite.Location = new System.Drawing.Point(309, 10);
            this.btnSetFavorite.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetFavorite.Name = "btnSetFavorite";
            this.btnSetFavorite.Size = new System.Drawing.Size(76, 27);
            this.btnSetFavorite.TabIndex = 6;
            this.btnSetFavorite.Text = "Set Favorite";
            this.btnSetFavorite.UseVisualStyleBackColor = true;
            this.btnSetFavorite.Click += new System.EventHandler(this.BtnSetFavorite_Click);
            // 
            // bckWorkerGetTeams
            // 
            this.bckWorkerGetTeams.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckWorkerGetTeams_DoWork);
            this.bckWorkerGetTeams.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bckWorkerGetTeams_RunWorkerCompleted);
            // 
            // bckWorkerGetPlayersByCode
            // 
            this.bckWorkerGetPlayersByCode.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BckWorkerGetPlayersByCode_DoWork);
            this.bckWorkerGetPlayersByCode.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BckWorkerGetPlayersByCode_RunWorkerCompleted);
            // 
            // ccPlayerDetails
            // 
            this.ccPlayerDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ccPlayerDetails.Location = new System.Drawing.Point(459, 77);
            this.ccPlayerDetails.Margin = new System.Windows.Forms.Padding(2);
            this.ccPlayerDetails.Name = "ccPlayerDetails";
            this.ccPlayerDetails.Size = new System.Drawing.Size(413, 266);
            this.ccPlayerDetails.TabIndex = 10;
            // 
            // playersControl
            // 
            this.playersControl.BackColor = System.Drawing.Color.Transparent;
            this.playersControl.Location = new System.Drawing.Point(9, 62);
            this.playersControl.Margin = new System.Windows.Forms.Padding(1);
            this.playersControl.Name = "playersControl";
            this.playersControl.Size = new System.Drawing.Size(434, 321);
            this.playersControl.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(892, 418);
            this.Controls.Add(this.ccPlayerDetails);
            this.Controls.Add(this.playersControl);
            this.Controls.Add(this.btnSetFavorite);
            this.Controls.Add(this.lbFavorite);
            this.Controls.Add(this.cbFavoriteTeams);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbFavoriteTeams;
        private System.Windows.Forms.Label lbFavorite;
        private System.Windows.Forms.Button btnSetFavorite;
        private playersControl playersControl;
        private System.ComponentModel.BackgroundWorker bckWorkerGetTeams;
        private System.ComponentModel.BackgroundWorker bckWorkerGetPlayersByCode;
        private Controls.PlayerDetails ccPlayerDetails;
    }
}