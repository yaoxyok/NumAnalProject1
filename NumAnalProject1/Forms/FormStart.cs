using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumAnalProject1.Forms
{
    /// <summary>
    /// The start form
    /// </summary>
    public partial class FormStart : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FormStart()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Go to Task 1 (rotation)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            (new Form1()).ShowDialog();
        }

        /// <summary>
        /// Go to Task 2 (ripple effect)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            (new Form2()).ShowDialog();
        }

        /// <summary>
        /// Go to Task 3 (B-spline)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            (new Form3()).ShowDialog();
        }
    }
}
