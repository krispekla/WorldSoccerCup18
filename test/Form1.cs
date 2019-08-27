using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            label1.DoDragDrop(label1, DragDropEffects.Copy |
      DragDropEffects.Move);
        }

        private void flow1_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                Label myObject = (Label)e.Data.GetData(e.Data.GetFormats()[0]);
                if (myObject != null)
                {
                    e.Effect = DragDropEffects.Copy;

                }
                else
                {

                    e.Effect = DragDropEffects.None;
                }
            }
            catch
            {
                throw;
            }
        }

        private void flow1_DragDrop(object sender, DragEventArgs e)
        {
            flow1.Controls.Add((Label)e.Data.GetData(e.Data.GetFormats()[0]));
        }

        private void flow2_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                Label myObject = (Label)e.Data.GetData(e.Data.GetFormats()[0]);
                if (myObject != null)
                {
                    e.Effect = DragDropEffects.Copy;

                }
                else
                {

                    e.Effect = DragDropEffects.None;
                }
            }
            catch
            {
                throw;
            }
        }

        private void flow2_DragDrop(object sender, DragEventArgs e)
        {
            flow2.Controls.Add((Label)e.Data.GetData(e.Data.GetFormats()[0]));

        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            label3.Text = "da"; 
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label3.Text = "da";

        }
    }
}
