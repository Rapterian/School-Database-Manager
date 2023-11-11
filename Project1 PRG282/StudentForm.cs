using Project1_PRG282.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Project1_PRG282.LogicLayer;

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

        int createCounter = 0;
        private void label3_Click(object sender, EventArgs e)
        {
            createCounter++;
            if (createCounter == 1)
            {
                lblUpdate.Enabled = false;
                lblDelete.Enabled = false;
                txtSearch.Enabled = false;
                btnAction.Text = "Create";
                btnAction.Visible = true;
                txtAdress.Text = "";
                txtName.Text = "";
                txtPhone.Text = "";
                txtSearch.Text = "";
                txtSurname.Text = "";
                txtName.Focus();
            }
            else if (createCounter > 1)
            {
                lblUpdate.Enabled = true;
                lblDelete.Enabled = true;
                txtSearch.Enabled = true;
                btnAction.Text = "--";
                btnAction.Visible = false;
                createCounter = 0;
            }
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            //This is for the DataGridView
            dgvStudent.DataSource = DataHandler.showStudentData();

            //This is for the List View
            foreach (DataRow row in DataHandler.showStudentData().Rows)
            {
                ListViewItem item = new ListViewItem(row["StudentNumber"].ToString());
                item.SubItems.Add(row["Name"].ToString());
                item.SubItems.Add(row["Surname"].ToString());
                item.SubItems.Add(row["StudentImage"].ToString());
                item.SubItems.Add(row["DOB"].ToString());
                item.SubItems.Add(row["Gender"].ToString());
                item.SubItems.Add(row["Phone"].ToString());
                item.SubItems.Add(row["Address"].ToString());
                item.SubItems.Add(row["ModuleCode"].ToString());
                lvStudent.Items.Add(item);
            }
        }

        private void label3_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        int updateCounter = 0;
        private void lblUpdate_Click(object sender, EventArgs e)
        {
            updateCounter++;
            if (updateCounter == 1) 
            {
                lblCreate.Enabled = false;
                lblDelete.Enabled = false;
                txtSearch.Enabled = false;
                btnAction.Text = "Update";
                btnAction.Visible = true;
            }
            else if (updateCounter > 1)
            {
                lblCreate.Enabled = true;
                lblDelete.Enabled = true;
                txtSearch.Enabled = true;
                btnAction.Visible = false;
                btnAction.Text = "--";
                updateCounter = 0;
            }
        }

        int deleteCounter = 0;
        private void lblDelete_Click(object sender, EventArgs e)
        {
            deleteCounter++;
            if (deleteCounter == 1)
            {
                lblCreate.Enabled = false;
                lblUpdate.Enabled = false;
                txtSearch.Enabled = false;
                btnAction.Visible = true;
                btnAction.Text = "Delete";
            }
            else if (deleteCounter > 1)
            {
                lblCreate.Enabled = true;
                lblUpdate.Enabled = true;
                txtSearch.Enabled = true;
                btnAction.Visible = false;
                btnAction.Text = "--";
                deleteCounter = 0;
            }
        }

        private void pbxHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            
        }

        private void StudentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        int currentRowIndex = 0;
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (dgvStudent.Rows.Count > 0)
            {
                dgvStudent.ClearSelection();
                dgvStudent.Rows[0].Selected = true;
                
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (dgvStudent.Rows.Count > 0)
            {
                currentRowIndex--;
                if (currentRowIndex < 0)
                {
                    currentRowIndex = dgvStudent.Rows.Count - 1;
                }
                dgvStudent.ClearSelection();
                dgvStudent.Rows[currentRowIndex].Selected = true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentRowIndex < dgvStudent.Rows.Count - 1)
            {
                currentRowIndex++;
                dgvStudent.ClearSelection();
                dgvStudent.Rows[currentRowIndex].Selected = true;
            }
            else
            {
                currentRowIndex = 0; // Must try and alter this so when going next from last row, it goes to first row (it goes to second row if clicked twice when at last row)
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (dgvStudent.Rows.Count > 0)
            {
                dgvStudent.ClearSelection();

                int lastIndex = dgvStudent.Rows.Count - 1;
                dgvStudent.Rows[lastIndex].Selected = true;

            }
        }

        private void lvStudent_MouseClick(object sender, MouseEventArgs e)
        {
            txtName.Text = lvStudent.SelectedItems[0].SubItems[1].Text;
            txtSurname.Text = lvStudent.SelectedItems[0].SubItems[2].Text;
            txtPhone.Text = lvStudent.SelectedItems[0].SubItems[6].Text;
            txtAdress.Text = lvStudent.SelectedItems[0].SubItems[7].Text;
            if (lvStudent.SelectedItems[0].SubItems[5].Text == "Male")
            {
                rbMale.Checked = true;
            } else
            {
                rbFemale.Checked = true;
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (btnAction.Text == "Create")
            {
                try
                {
                    Student student = new Student("Dont know what to put here");

                    DataHandler.createStudent(student);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (btnAction.Text == "Update")
            {
                try
                {
                    Student student = new Student("Dont know what to put here");

                    DataHandler.updateStudent(student);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (btnAction.Text == "Delete")
            {
                string name = txtName.Text;

                DataHandler.deleteStudent(name);
            }
        }

        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dgvStudent.Rows[e.RowIndex];

                txtName.Text = row.Cells["Name"].Value.ToString();
                txtSurname.Text = row.Cells["Surname"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                txtAdress.Text = row.Cells["Address"].Value.ToString();
                rtbxCourseCodes.Text = row.Cells["ModuleCode"].Value.ToString();
            }
        }
    }
}
