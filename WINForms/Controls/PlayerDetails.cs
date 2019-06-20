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
using System.Drawing.Imaging;
using System.IO;

namespace WINForms.Controls
{
    public partial class PlayerDetails : UserControl
    {
        public delegate void ComboBoxSelectedPlayerDetailsSelectedValueChangedHandler(object sender, EventArgs e);
        public event ComboBoxSelectedPlayerDetailsSelectedValueChangedHandler ComboBoxSelectedPlayerDetailsSelectedValueChanged;

        public delegate void ButtonDetailsChangePictureHandler(object sender, EventArgs e);
        public event ButtonDetailsChangePictureHandler ButtonDetailsChangePictureClick;


        public PlayerDetails()
        {
            InitializeComponent();
        }

        public void ShowPlayerDetails(Player player)
        {
            if (String.IsNullOrEmpty(cbSelectedPlayerDetails.Text)) return;

            lbDetailsName.Text = player.Name.ToString();
            lbDetailsCaptain.Text = player.Captain ? "Yes" : "No";
            lbDetailsShirt.Text = player.Shirt_number.ToString();
            lbDetailsPosition.Text = player.Position;
            lbDetailsFavorite.Text = player.Favorite ? "Yes" : "No";

            if (String.IsNullOrEmpty(player.Image))
            {
                string defaultImage = @"players\img\default.jpg";
                pbDetailsPicture.Image = new Bitmap(defaultImage);
            }
            else
            {
                pbDetailsPicture.Image = new Bitmap(player.Image);
            }
        }

        private void CbSelectedPlayerDetails_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ComboBoxSelectedPlayerDetailsSelectedValueChanged != null)
            {
                ComboBoxSelectedPlayerDetailsSelectedValueChanged(sender, e);
            }
        }

        private void btnDetailsChangePicture_Click(object sender, EventArgs e)
        {
            if (ButtonDetailsChangePictureClick != null)
            {
                ButtonDetailsChangePictureClick(sender, e);
            }





        }
    }
}
