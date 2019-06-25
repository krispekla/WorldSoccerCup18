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
            this.lbSelectTeam = new System.Windows.Forms.Label();
            this.cbTeamsList = new System.Windows.Forms.ComboBox();
            this.btnSetFavorite = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbSelectTeam
            // 
            this.lbSelectTeam.AutoSize = true;
            this.lbSelectTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSelectTeam.Location = new System.Drawing.Point(27, 18);
            this.lbSelectTeam.Name = "lbSelectTeam";
            this.lbSelectTeam.Size = new System.Drawing.Size(91, 17);
            this.lbSelectTeam.TabIndex = 0;
            this.lbSelectTeam.Text = "Select Team:";
            // 
            // cbTeamsList
            // 
            this.cbTeamsList.BackColor = System.Drawing.Color.White;
            this.cbTeamsList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbTeamsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTeamsList.FormattingEnabled = true;
            this.cbTeamsList.Location = new System.Drawing.Point(146, 17);
            this.cbTeamsList.Name = "cbTeamsList";
            this.cbTeamsList.Size = new System.Drawing.Size(167, 21);
            this.cbTeamsList.TabIndex = 1;
            this.cbTeamsList.SelectedValueChanged += new System.EventHandler(this.CbTeamsList_SelectedValueChanged);
            // 
            // btnSetFavorite
            // 
            this.btnSetFavorite.BackColor = System.Drawing.Color.White;
            this.btnSetFavorite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetFavorite.Location = new System.Drawing.Point(362, 8);
            this.btnSetFavorite.Name = "btnSetFavorite";
            this.btnSetFavorite.Size = new System.Drawing.Size(115, 37);
            this.btnSetFavorite.TabIndex = 2;
            this.btnSetFavorite.Text = "Set Favorite Team";
            this.btnSetFavorite.UseVisualStyleBackColor = false;
            this.btnSetFavorite.Click += new System.EventHandler(this.BtnSetFavorite_Click);
            // 
            // TeamSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSetFavorite);
            this.Controls.Add(this.cbTeamsList);
            this.Controls.Add(this.lbSelectTeam);
            this.Name = "TeamSelect";
            this.Size = new System.Drawing.Size(521, 64);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbSelectTeam;
        public System.Windows.Forms.ComboBox cbTeamsList;
        public System.Windows.Forms.Button btnSetFavorite;
    }
}
