using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphics_lab_9
{
    public partial class Form1 : Form
    {
        Bitmap foreground;
        Bitmap background;

        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                background = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = background;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreground = new Bitmap(openFileDialog1.FileName);
            }
        }

        private void DrawObject(object sender, PaintEventArgs e)
        {
            if (foreground == null)
                return;

            Bitmap temp = background;

            Point foregroundPosition = new Point()
            {
                X = (temp.Width / 2 - foreground.Width / 2),
                Y = (temp.Height / 2 - foreground.Height / 2)
            };
            Graphics gr = Graphics.FromImage(temp);
            gr.DrawImage(foreground, foregroundPosition);

            pictureBox1.Image = temp;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog1.FileName);
            }
        }
    }
}