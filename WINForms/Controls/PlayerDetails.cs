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
    public partial class PlayerDetails : UserControl
    {
        public bool Favorite { get; set; }
        public PlayerDetails()
        {
            InitializeComponent();
        }

        public void ShowPlayerDetails(Player player)
        {
            lbName.Text = $"{player.Name} {(player.Favorite ? "*" : "")}";
            lbShirtNumber.Text = player.Shirt_number.ToString();
            lbPosition.Text = player.Position;
            lbCaptain.Text = player.Captain ? "Yes" : "No";

            Favorite = player.Favorite;

            if (String.IsNullOrEmpty(player.Image))
            {
                string defaultImage = @"players\img\default.jpg";
                pbPicture.Image = new Bitmap(defaultImage);
            }
            else
            {
                pbPicture.Image = new Bitmap(player.Image);
            }
            Refresh();
        }

    }
}
