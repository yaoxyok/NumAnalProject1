using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumAnalProject1.Forms
{
    partial class FormRawImage : Form
    {
        public FormRawImage(Image image)
        {
            InitializeComponent();
            box = new PictureBox();
            box.Image = image;
            box.Size = new Size(image.Size.Width, image.Size.Height);
            box.Click += this.panel_Click;
            panel.Controls.Add(box);
        }

        protected void panel_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = Application.StartupPath + "\\..\\results";
            dialog.Filter = "暂仅支持bmp格式|*.bmp";
            dialog.RestoreDirectory = true;
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = dialog.FileName;
                box.Image.Save(fileName);
            }
        }

        protected PictureBox box;

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
