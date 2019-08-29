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
using System.IO;

namespace WINForms.Controls
{
    public partial class PlayerDetails : UserControl
    {
        public bool Favorite { get; set; }
        public bool IsSelected { get; set; }
        public Player Player { get; set; }
        public bool ignoreClick = false;

        public delegate void PlayerDetailsClickHandler(object sender, MouseEventArgs e);
        public event PlayerDetailsClickHandler PlayerDetailsClick;

        public delegate void PlayerDetailsChangePictureClickHandler(object sender, EventArgs e);
        public event PlayerDetailsChangePictureClickHandler PlayerDetailsChangePictureClick;

        public PlayerDetails()
        {
            Player = new Player();
            IsSelected = false;
            InitializeComponent();
        }

        public void ShowPlayerDetails(Player player)
        {
            Player p = new Player()
            {
                Name = player.Name,
                Captain = player.Captain,
                Shirt_number = player.Shirt_number,
                Position = player.Position,
                Favorite = player.Favorite,
                Image = player.Image
            };

            Player = p;

            lbName.Text = $"{player.Name} {(player.Favorite ? "*" : "")}";
            lbShirtNumber.Text = player.Shirt_number.ToString();
            lbPosition.Text = player.Position;
            lbCaptain.Text = player.Captain ? "Yes" : "No";

            Favorite = player.Favorite;

            Image img;
            if (String.IsNullOrEmpty(player.Image))
            {
                using (var bmpTemp = new Bitmap(WINForms.Properties.Resources._default))
                {
                    img = new Bitmap(bmpTemp);
                }
                pbPicture.Image = new Bitmap(img);
            }
            else
            {
                using (var bmpTemp = new Bitmap(player.Image))
                {
                    img = new Bitmap(bmpTemp);
                }
                pbPicture.Image = new Bitmap(img);
            }
            Refresh();
        }

        public void SetSelected()
        {
            if (IsSelected)
            {
                BackColor = Color.White;
                IsSelected = false;
            }
            else
            {
                BackColor = Color.Aqua;
                IsSelected = true;
            }
            Refresh();
        }

        private void PlayerDetails_MouseClick(object sender, MouseEventArgs e)
        {
            PlayerDetailsClick?.Invoke(sender, e);
        }

        private void BtnChangePicture_Click(object sender, EventArgs e)
        {
            PlayerDetailsChangePictureClick?.Invoke(Player, e);
        }

    }
}
