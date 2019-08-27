using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WINForms.Forms
{
    public partial class Language : Form
    {
        private static bool _firstRun;

        public Language(bool firstRun)
        {
            _firstRun = firstRun;
            InitializeComponent();
            cbLanguage.Items.AddRange(new String[] { "English", "Hrvatski" });
            
            UpdateLanguagePreferences();
        }

        private void UpdateLanguagePreferences()
        {
            string lang = FileRepository.ReadLanguagePreference();
            if (lang == "English")
            {
                cbLanguage.SelectedIndex = 0;
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            }
            else
            {
                cbLanguage.SelectedIndex = 1;
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("hr");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("hr");
                this.Refresh();
            }
        }

        private void btnSaveLanguage_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();
            if (!_firstRun)
            {
                
                result = MessageBox.Show(GlobalStrings.AreYouCertain,
                    GlobalStrings.Save, MessageBoxButtons.YesNo);

            }
            if (result == DialogResult.No)
                Close();

            else
            {
                Repository.WriteLanguagePreference(cbLanguage.GetItemText(cbLanguage.SelectedItem));
                Close();
            }
        }


    }
}
