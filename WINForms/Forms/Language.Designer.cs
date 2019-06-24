namespace WINForms.Forms
{
    partial class Language
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.pnlLanguageDropdown = new System.Windows.Forms.Panel();
            this.btnSaveLanguage = new System.Windows.Forms.Button();
            this.pnlLanguageDropdown.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(94, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chose language:";
            // 
            // cbLanguage
            // 
            this.cbLanguage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Location = new System.Drawing.Point(104, 154);
            this.cbLanguage.Margin = new System.Windows.Forms.Padding(6);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(338, 39);
            this.cbLanguage.TabIndex = 1;
            // 
            // pnlLanguageDropdown
            // 
            this.pnlLanguageDropdown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlLanguageDropdown.Controls.Add(this.btnSaveLanguage);
            this.pnlLanguageDropdown.Controls.Add(this.label1);
            this.pnlLanguageDropdown.Controls.Add(this.cbLanguage);
            this.pnlLanguageDropdown.Location = new System.Drawing.Point(506, 327);
            this.pnlLanguageDropdown.Margin = new System.Windows.Forms.Padding(6);
            this.pnlLanguageDropdown.Name = "pnlLanguageDropdown";
            this.pnlLanguageDropdown.Size = new System.Drawing.Size(548, 388);
            this.pnlLanguageDropdown.TabIndex = 2;
            // 
            // btnSaveLanguage
            // 
            this.btnSaveLanguage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveLanguage.Location = new System.Drawing.Point(192, 277);
            this.btnSaveLanguage.Margin = new System.Windows.Forms.Padding(6);
            this.btnSaveLanguage.Name = "btnSaveLanguage";
            this.btnSaveLanguage.Size = new System.Drawing.Size(176, 65);
            this.btnSaveLanguage.TabIndex = 2;
            this.btnSaveLanguage.Text = "Save";
            this.btnSaveLanguage.UseVisualStyleBackColor = true;
            this.btnSaveLanguage.Click += new System.EventHandler(this.btnSaveLanguage_Click);
            // 
            // Language
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1520, 952);
            this.Controls.Add(this.pnlLanguageDropdown);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Language";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Language";
            this.pnlLanguageDropdown.ResumeLayout(false);
            this.pnlLanguageDropdown.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbLanguage;
        private System.Windows.Forms.Panel pnlLanguageDropdown;
        private System.Windows.Forms.Button btnSaveLanguage;
    }
}