using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1_PRG282
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            button5.Visible = true;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            button5.Text = "Create";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
