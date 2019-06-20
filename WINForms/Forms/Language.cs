using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WINForms.Forms
{
    public partial class Language : Form
    {
        public Language()
        {
            InitializeComponent();
            cbLanguage.Items.AddRange(new String[] { "English", "Hrvatski" });
            cbLanguage.SelectedIndex = 0;
            //    cbLanguage.SelectedIndex = cbLanguage.FindString(lang);

        }

        private void btnSaveLanguage_Click(object sender, EventArgs e)
        {
            Repository.WriteLanguagePreference(cbLanguage.GetItemText(cbLanguage.SelectedItem));
            Close();
        }
    }
}
