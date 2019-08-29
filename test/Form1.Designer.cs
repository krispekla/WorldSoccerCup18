namespace test
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flow1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flow2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.flow2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flow1
            // 
            this.flow1.AllowDrop = true;
            this.flow1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.flow1.Location = new System.Drawing.Point(97, 92);
            this.flow1.Name = "flow1";
            this.flow1.Size = new System.Drawing.Size(256, 250);
            this.flow1.TabIndex = 0;
            this.flow1.DragDrop += new System.Windows.Forms.DragEventHandler(this.flow1_DragDrop);
            this.flow1.DragEnter += new System.Windows.Forms.DragEventHandler(this.flow1_DragEnter);
            // 
            // flow2
            // 
            this.flow2.AllowDrop = true;
            this.flow2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.flow2.Controls.Add(this.label1);
            this.flow2.Controls.Add(this.label2);
            this.flow2.Location = new System.Drawing.Point(448, 92);
            this.flow2.Name = "flow2";
            this.flow2.Size = new System.Drawing.Size(295, 250);
            this.flow2.TabIndex = 1;
            this.flow2.DragDrop += new System.Windows.Forms.DragEventHandler(this.flow2_DragDrop);
            this.flow2.DragEnter += new System.Windows.Forms.DragEventHandler(this.flow2_DragEnter);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label1_MouseClick);
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Coral;
            this.label2.Location = new System.Drawing.Point(150, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 54);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(368, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.flow2);
            this.Controls.Add(this.flow1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flow2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flow1;
        private System.Windows.Forms.FlowLayoutPanel flow2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

