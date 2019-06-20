using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WINForms
{
    public partial class playersControl : UserControl
    {
        public delegate void ListBoxOthersDoubleClickHandler(object sender, EventArgs e);
        public event ListBoxOthersDoubleClickHandler ListBoxOthersDoubleClick;

        public delegate void ListBoxFavoritesDoubleClickHandler(object sender, EventArgs e);
        public event ListBoxFavoritesDoubleClickHandler ListBoxFavoritesDoubleClick;

        public playersControl()
        {
            InitializeComponent();
        }

        private void lbOtherPlayers_DoubleClick(object sender, EventArgs e)
        {
            if (ListBoxOthersDoubleClick != null)
            {
                ListBoxOthersDoubleClick(sender, e);
            }
        }


        private void lbFavoritePlayers_DoubleClick(object sender, EventArgs e)
        {
            if (ListBoxFavoritesDoubleClick != null)
            {
                ListBoxFavoritesDoubleClick(sender, e);
            }
        }
    }
}
