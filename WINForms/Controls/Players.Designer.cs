namespace WINForms
{
    partial class playersControl
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
            this.pnlPlayers = new System.Windows.Forms.Panel();
            this.lbFavoritePlayers = new System.Windows.Forms.ListBox();
            this.pnlOtherPlayers = new System.Windows.Forms.Panel();
            this.lbOtherPlayers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlPlayers.SuspendLayout();
            this.pnlOtherPlayers.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPlayers
            // 
            this.pnlPlayers.Controls.Add(this.lbFavoritePlayers);
            this.pnlPlayers.Location = new System.Drawing.Point(21, 100);
            this.pnlPlayers.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlPlayers.Name = "pnlPlayers";
            this.pnlPlayers.Size = new System.Drawing.Size(233, 96);
            this.pnlPlayers.TabIndex = 0;
            // 
            // lbFavoritePlayers
            // 
            this.lbFavoritePlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFavoritePlayers.FormattingEnabled = true;
            this.lbFavoritePlayers.ItemHeight = 16;
            this.lbFavoritePlayers.Location = new System.Drawing.Point(0, 0);
            this.lbFavoritePlayers.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbFavoritePlayers.Name = "lbFavoritePlayers";
            this.lbFavoritePlayers.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbFavoritePlayers.Size = new System.Drawing.Size(233, 96);
            this.lbFavoritePlayers.TabIndex = 0;
            this.lbFavoritePlayers.DoubleClick += new System.EventHandler(this.lbFavoritePlayers_DoubleClick);
            // 
            // pnlOtherPlayers
            // 
            this.pnlOtherPlayers.Controls.Add(this.lbOtherPlayers);
            this.pnlOtherPlayers.Location = new System.Drawing.Point(315, 100);
            this.pnlOtherPlayers.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlOtherPlayers.Name = "pnlOtherPlayers";
            this.pnlOtherPlayers.Size = new System.Drawing.Size(247, 257);
            this.pnlOtherPlayers.TabIndex = 1;
            // 
            // lbOtherPlayers
            // 
            this.lbOtherPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbOtherPlayers.FormattingEnabled = true;
            this.lbOtherPlayers.ItemHeight = 16;
            this.lbOtherPlayers.Location = new System.Drawing.Point(0, 0);
            this.lbOtherPlayers.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbOtherPlayers.Name = "lbOtherPlayers";
            this.lbOtherPlayers.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbOtherPlayers.Size = new System.Drawing.Size(247, 257);
            this.lbOtherPlayers.TabIndex = 0;
            this.lbOtherPlayers.DoubleClick += new System.EventHandler(this.lbOtherPlayers_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Favorite players:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(400, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Players:";
            // 
            // playersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlOtherPlayers);
            this.Controls.Add(this.pnlPlayers);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "playersControl";
            this.Size = new System.Drawing.Size(729, 387);
            this.pnlPlayers.ResumeLayout(false);
            this.pnlOtherPlayers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPlayers;
        private System.Windows.Forms.Panel pnlOtherPlayers;
        public System.Windows.Forms.ListBox lbOtherPlayers;
        public System.Windows.Forms.ListBox lbFavoritePlayers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
