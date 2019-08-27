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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Language));
            this.label1 = new System.Windows.Forms.Label();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.pnlLanguageDropdown = new System.Windows.Forms.Panel();
            this.btnSaveLanguage = new System.Windows.Forms.Button();
            this.pnlLanguageDropdown.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cbLanguage
            // 
            resources.ApplyResources(this.cbLanguage, "cbLanguage");
            this.cbLanguage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Name = "cbLanguage";
            // 
            // pnlLanguageDropdown
            // 
            resources.ApplyResources(this.pnlLanguageDropdown, "pnlLanguageDropdown");
            this.pnlLanguageDropdown.Controls.Add(this.btnSaveLanguage);
            this.pnlLanguageDropdown.Controls.Add(this.label1);
            this.pnlLanguageDropdown.Controls.Add(this.cbLanguage);
            this.pnlLanguageDropdown.Name = "pnlLanguageDropdown";
            // 
            // btnSaveLanguage
            // 
            resources.ApplyResources(this.btnSaveLanguage, "btnSaveLanguage");
            this.btnSaveLanguage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveLanguage.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSaveLanguage.Name = "btnSaveLanguage";
            this.btnSaveLanguage.UseVisualStyleBackColor = true;
            this.btnSaveLanguage.Click += new System.EventHandler(this.btnSaveLanguage_Click);
            // 
            // Language
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlLanguageDropdown);
            this.KeyPreview = true;
            this.Name = "Language";
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