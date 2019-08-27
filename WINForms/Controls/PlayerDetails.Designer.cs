namespace WINForms.Controls
{
    partial class PlayerDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerDetails));
            this.pbPicture = new System.Windows.Forms.PictureBox();
            this.btnChangePicture = new System.Windows.Forms.Button();
            this.lbN = new System.Windows.Forms.Label();
            this.lbSN = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbP = new System.Windows.Forms.Label();
            this.lbC = new System.Windows.Forms.Label();
            this.lbCaptain = new System.Windows.Forms.Label();
            this.lbPosition = new System.Windows.Forms.Label();
            this.lbShirtNumber = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbPicture
            // 
            resources.ApplyResources(this.pbPicture, "pbPicture");
            this.pbPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPicture.Image = global::WINForms.Properties.Resources._default;
            this.pbPicture.InitialImage = global::WINForms.Properties.Resources._default;
            this.pbPicture.Name = "pbPicture";
            this.pbPicture.TabStop = false;
            // 
            // btnChangePicture
            // 
            resources.ApplyResources(this.btnChangePicture, "btnChangePicture");
            this.btnChangePicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePicture.Name = "btnChangePicture";
            this.btnChangePicture.UseVisualStyleBackColor = true;
            this.btnChangePicture.Click += new System.EventHandler(this.BtnChangePicture_Click);
            // 
            // lbN
            // 
            resources.ApplyResources(this.lbN, "lbN");
            this.lbN.Name = "lbN";
            // 
            // lbSN
            // 
            resources.ApplyResources(this.lbSN, "lbSN");
            this.lbSN.Name = "lbSN";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.lbN, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbSN, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbP, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbC, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbCaptain, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbPosition, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbShirtNumber, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbName, 1, 0);
            this.tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // lbP
            // 
            resources.ApplyResources(this.lbP, "lbP");
            this.lbP.Name = "lbP";
            // 
            // lbC
            // 
            resources.ApplyResources(this.lbC, "lbC");
            this.lbC.Name = "lbC";
            // 
            // lbCaptain
            // 
            resources.ApplyResources(this.lbCaptain, "lbCaptain");
            this.lbCaptain.Name = "lbCaptain";
            // 
            // lbPosition
            // 
            resources.ApplyResources(this.lbPosition, "lbPosition");
            this.lbPosition.Name = "lbPosition";
            // 
            // lbShirtNumber
            // 
            resources.ApplyResources(this.lbShirtNumber, "lbShirtNumber");
            this.lbShirtNumber.Name = "lbShirtNumber";
            // 
            // lbName
            // 
            resources.ApplyResources(this.lbName, "lbName");
            this.lbName.Name = "lbName";
            // 
            // PlayerDetails
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnChangePicture);
            this.Controls.Add(this.pbPicture);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "PlayerDetails";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PlayerDetails_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlayerDetails_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPicture;
        private System.Windows.Forms.Label lbN;
        private System.Windows.Forms.Label lbSN;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbP;
        private System.Windows.Forms.Label lbC;
        public System.Windows.Forms.Button btnChangePicture;
        public System.Windows.Forms.Label lbName;
        public System.Windows.Forms.Label lbShirtNumber;
        public System.Windows.Forms.Label lbPosition;
        public System.Windows.Forms.Label lbCaptain;
    }
}
