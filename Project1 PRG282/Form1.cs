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
            string filePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Users.txt");

            try
            {
                // Create a StreamWriter to write to the file
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(txtUsername.Text); 
                    writer.WriteLine(txtPassword.Text); 
                }

                MessageBox.Show("Text file created at: " + filePath);
                //If the file was created, it will show a message saying its created
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating the file: " + ex.Message);
                //If the file was not created, it will show a message saying its not created
            }


            if (File.Exists(filePath))//Check to see if file exits
            {
                try
                {
                    string[] lines = File.ReadAllLines(filePath);//reads all the lines in the textfile

                    if (lines.Length >= 2)//valodates to see if the user only inputs 2 values (Username & password)
                    {
                        string Username = lines[0];
                        string Password = lines[1];

                        string username = txtUsername.Text;
                        string password = txtPassword.Text;

                        if (username == Username && password == Password)//compares the entered text with the text in the text file
                        {
                            MessageBox.Show("Login successful");
                            //if the text was the same, it will say the login was successful
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Username or Password");
                            //if the text was not the same, it will say the login was not successful
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorrect format");
                        //if the user has input more than 2 values then it will say that the format is incorrect
                    }
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message);//if the program can't read the text file it will show an error message
                }
                
            }
            else
            {
                MessageBox.Show("Text file not found");
                //if the file does not exist it will say the text file was not found
            }

            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Hide();
        }

    }
}
