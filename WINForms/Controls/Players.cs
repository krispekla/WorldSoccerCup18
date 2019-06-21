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



        public delegate void ToFavoritesMenuItemHandler(object sender, EventArgs e);
        public event ToFavoritesMenuItemHandler MenuItemToFavoritesClick;

        public delegate void ToOthersMenuItemHandler(object sender, EventArgs e);
        public event ToOthersMenuItemHandler MenuItemToOthersClick;

        public delegate void ResetFavoritesMenuItemHandler(object sender, EventArgs e);
        public event ResetFavoritesMenuItemHandler MenuItemResetFavoritesClick;

        public delegate void OthersDoDragMouseDownHandler(object sender, MouseEventArgs e);
        public event OthersDoDragMouseDownHandler OthersDoDragMouseDown;
        


        public playersControl()
        {
            InitializeComponent();
            ContextMenu cmSwitchFavorites = new ContextMenu();
        }

        private void LbOtherPlayers_DoubleClick(object sender, EventArgs e)
        {
            ListBoxOthersDoubleClick?.Invoke(sender, e);
        }


        private void LbFavoritePlayers_DoubleClick(object sender, EventArgs e)
        {
            ListBoxFavoritesDoubleClick?.Invoke(sender, e);
        }



        private void ToFavoritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItemToFavoritesClick?.Invoke(sender, e);

        }

        private void ToOthersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItemToOthersClick?.Invoke(sender, e);

        }

        private void ResetFavoritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItemResetFavoritesClick?.Invoke(sender, e);

        }

        private void lbOtherPlayers_MouseDown(object sender, MouseEventArgs e)
        {
            OthersDoDragMouseDown?.Invoke(sender, e);
        }
    }
}
