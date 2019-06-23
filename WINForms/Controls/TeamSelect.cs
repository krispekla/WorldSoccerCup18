using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Models;

namespace WINForms.Controls
{
    public partial class TeamSelect : UserControl
    {
        public delegate void cbTeamsListSelectedValueChangedHandler(object sender, EventArgs e);
        public event cbTeamsListSelectedValueChangedHandler CbTeamsListSelectedValueChanged;

        public delegate void btnSetFavoriteClickHandler(object sender, EventArgs e);
        public event btnSetFavoriteClickHandler BtnSetFavoriteClick;

        public TeamSelect()
        {
            InitializeComponent();
        }

        internal void LoadTeamsAndFavorite(List<Team> teams, string favorite)
        {
            foreach (Team t in teams)
            {
                cbTeamsList.Items.Add(string.Format("{0} {1}", t.Country, t.Fifa_code));
            }

            if (!String.IsNullOrEmpty(favorite))
            {
                int index = teams.FindIndex(y => y.Country == favorite);
                cbTeamsList.SelectedIndex = teams.FindIndex(x => x.Country == favorite);
            }
            else
                cbTeamsList.SelectedIndex = 0;

            Refresh();
        }

        private void BtnSetFavorite_Click(object sender, EventArgs e)
        {
            BtnSetFavoriteClick?.Invoke(sender, e);
        }

        private void cbTeamsList_SelectedValueChanged(object sender, EventArgs e)
        {
            CbTeamsListSelectedValueChanged?.Invoke(sender, e);
        }
    }
}
