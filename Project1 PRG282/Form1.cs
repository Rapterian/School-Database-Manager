using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project1_PRG282
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }

        private void pnlLogInContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Hide();

            

            string filePath = Application.ExecutablePath + "Users.txt";

            string Username = txtUsername.Text;
            string Password = txtPassword.Text;

            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.Write(txtUsername.Text);
                sw.Write(txtPassword.Text);
            }

            string[] lines = File.ReadAllLines(filePath);

            bool login = false;

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length == 2)
                {
                    string username = parts[0];
                    string password = parts[1];

                    if (Username == username && Password == password)
                    {
                        login = true;
                        break;
                    }
                }
            }
        }

    }
}
