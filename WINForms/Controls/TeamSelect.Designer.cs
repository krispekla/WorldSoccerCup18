namespace WINForms.Controls
{
    partial class TeamSelect
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamSelect));
            this.lbSelectTeam = new System.Windows.Forms.Label();
            this.cbTeamsList = new System.Windows.Forms.ComboBox();
            this.btnSetFavorite = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbSelectTeam
            // 
            resources.ApplyResources(this.lbSelectTeam, "lbSelectTeam");
            this.lbSelectTeam.Name = "lbSelectTeam";
            // 
            // cbTeamsList
            // 
            resources.ApplyResources(this.cbTeamsList, "cbTeamsList");
            this.cbTeamsList.BackColor = System.Drawing.Color.White;
            this.cbTeamsList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbTeamsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTeamsList.FormattingEnabled = true;
            this.cbTeamsList.Name = "cbTeamsList";
            this.cbTeamsList.SelectedValueChanged += new System.EventHandler(this.CbTeamsList_SelectedValueChanged);
            // 
            // btnSetFavorite
            // 
            resources.ApplyResources(this.btnSetFavorite, "btnSetFavorite");
            this.btnSetFavorite.BackColor = System.Drawing.Color.White;
            this.btnSetFavorite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetFavorite.Name = "btnSetFavorite";
            this.btnSetFavorite.UseVisualStyleBackColor = false;
            this.btnSetFavorite.Click += new System.EventHandler(this.BtnSetFavorite_Click);
            // 
            // TeamSelect
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSetFavorite);
            this.Controls.Add(this.cbTeamsList);
            this.Controls.Add(this.lbSelectTeam);
            this.Name = "TeamSelect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbSelectTeam;
        public System.Windows.Forms.ComboBox cbTeamsList;
        public System.Windows.Forms.Button btnSetFavorite;
    }
}
