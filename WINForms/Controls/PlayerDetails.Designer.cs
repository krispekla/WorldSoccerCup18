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
            this.pbPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPicture.Image = global::WINForms.Properties.Resources._default;
            this.pbPicture.InitialImage = global::WINForms.Properties.Resources._default;
            this.pbPicture.Location = new System.Drawing.Point(12, 12);
            this.pbPicture.Name = "pbPicture";
            this.pbPicture.Size = new System.Drawing.Size(94, 88);
            this.pbPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPicture.TabIndex = 0;
            this.pbPicture.TabStop = false;
            // 
            // btnChangePicture
            // 
            this.btnChangePicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePicture.Location = new System.Drawing.Point(22, 111);
            this.btnChangePicture.Name = "btnChangePicture";
            this.btnChangePicture.Size = new System.Drawing.Size(75, 26);
            this.btnChangePicture.TabIndex = 1;
            this.btnChangePicture.Text = "Change";
            this.btnChangePicture.UseVisualStyleBackColor = true;
            // 
            // lbN
            // 
            this.lbN.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbN.AutoSize = true;
            this.lbN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbN.Location = new System.Drawing.Point(48, 7);
            this.lbN.Name = "lbN";
            this.lbN.Size = new System.Drawing.Size(38, 13);
            this.lbN.TabIndex = 2;
            this.lbN.Text = "Name:";
            this.lbN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbSN
            // 
            this.lbSN.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbSN.AutoSize = true;
            this.lbSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSN.Location = new System.Drawing.Point(17, 34);
            this.lbSN.Name = "lbSN";
            this.lbSN.Size = new System.Drawing.Size(69, 13);
            this.lbSN.TabIndex = 3;
            this.lbSN.Text = "Shirt number:";
            this.lbSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.68932F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.31068F));
            this.tableLayoutPanel1.Controls.Add(this.lbN, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbSN, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbP, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbC, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbCaptain, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbPosition, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbShirtNumber, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbName, 1, 0);
            this.tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(122, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00063F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.99813F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(204, 111);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // lbP
            // 
            this.lbP.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbP.AutoSize = true;
            this.lbP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbP.Location = new System.Drawing.Point(39, 61);
            this.lbP.Name = "lbP";
            this.lbP.Size = new System.Drawing.Size(47, 13);
            this.lbP.TabIndex = 4;
            this.lbP.Text = "Position:";
            this.lbP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbC
            // 
            this.lbC.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbC.AutoSize = true;
            this.lbC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbC.Location = new System.Drawing.Point(40, 89);
            this.lbC.Name = "lbC";
            this.lbC.Size = new System.Drawing.Size(46, 13);
            this.lbC.TabIndex = 5;
            this.lbC.Text = "Captain:";
            this.lbC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbCaptain
            // 
            this.lbCaptain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbCaptain.AutoSize = true;
            this.lbCaptain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCaptain.Location = new System.Drawing.Point(141, 89);
            this.lbCaptain.Name = "lbCaptain";
            this.lbCaptain.Size = new System.Drawing.Size(11, 13);
            this.lbCaptain.TabIndex = 9;
            this.lbCaptain.Text = "-";
            this.lbCaptain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPosition
            // 
            this.lbPosition.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbPosition.AutoSize = true;
            this.lbPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPosition.Location = new System.Drawing.Point(141, 61);
            this.lbPosition.Name = "lbPosition";
            this.lbPosition.Size = new System.Drawing.Size(11, 13);
            this.lbPosition.TabIndex = 8;
            this.lbPosition.Text = "-";
            this.lbPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbShirtNumber
            // 
            this.lbShirtNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbShirtNumber.AutoSize = true;
            this.lbShirtNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbShirtNumber.Location = new System.Drawing.Point(141, 34);
            this.lbShirtNumber.Name = "lbShirtNumber";
            this.lbShirtNumber.Size = new System.Drawing.Size(11, 13);
            this.lbShirtNumber.TabIndex = 7;
            this.lbShirtNumber.Text = "-";
            this.lbShirtNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbName
            // 
            this.lbName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(141, 7);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(11, 13);
            this.lbName.TabIndex = 6;
            this.lbName.Text = "-";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnChangePicture);
            this.Controls.Add(this.pbPicture);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "PlayerDetails";
            this.Padding = new System.Windows.Forms.Padding(50);
            this.Size = new System.Drawing.Size(339, 150);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PlayerDetails_MouseClick);
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
