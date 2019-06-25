﻿using System;
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
        public bool IsSelected { get; set; }
        public delegate void PlayerDetailsClickHandler(object sender, MouseEventArgs e);
        public event PlayerDetailsClickHandler PlayerDetailsClick;


        public PlayerDetails()
        {
            IsSelected = false;
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
    }
}
