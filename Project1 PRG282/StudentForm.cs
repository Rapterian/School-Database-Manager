
using Project1_PRG282.DataAccess;
using Project1_PRG282.LogicLayer;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        
        private void lblCreate_Click(object sender, EventArgs e)
        {
            
            if (btnAction.Text.Equals("--"))
            {
                lblCreate.Text = "Cancel";
                lblUpdate.Enabled = false;
                lblDelete.Enabled = false;
                txtSearch.Enabled = false;
                btnAction.Text = "Create";
                btnAction.Visible = true;
                btnAddCourseCodes.Visible = true;
                cbxCourseCodes.Visible = true;
                txtAdress.Text = "";
                txtName.Text = "";
                txtPhone.Text = "";
                txtSearch.Text = "";
                txtSurname.Text = "";
                txtName.Focus();
            }
            else if (btnAction.Text.Equals("Create"))
            {
                lblCreate.Text = "Create";
                lblUpdate.Enabled = true;
                lblDelete.Enabled = true;
                txtSearch.Enabled = true;
                btnAddCourseCodes.Visible = false;
                cbxCourseCodes.Visible = false;
                btnAction.Visible = false;
                btnAction.Text = "--";
                
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

        
        private void lblUpdate_Click(object sender, EventArgs e)
        {
            
            if (btnAction.Text.Equals("--")) 
            {
                lblUpdate.Text = "Cancel";
                lblCreate.Enabled = false;
                lblDelete.Enabled = false;
                txtSearch.Enabled = false;
                btnAction.Visible = true;
                btnAddCourseCodes.Visible = true;
                cbxCourseCodes.Visible = true;
                btnAction.Text = "Update";
                
            }
            else if (btnAction.Text.Equals("Update"))
            {
                lblUpdate.Text = "Update";
                lblCreate.Enabled = true;
                lblDelete.Enabled = true;
                txtSearch.Enabled = true;
                btnAction.Visible = false;
                btnAddCourseCodes.Visible = false;
                cbxCourseCodes.Visible = false;
                btnAction.Text = "--";
                
            }
        }
        private void lblDelete_Click(object sender, EventArgs e)
        {
            
            if (lblCreate.Enabled == true)
            {
                lblDelete.Text = "Cancel";
                lblCreate.Enabled = false;
                lblUpdate.Enabled = false;
                txtSearch.Enabled = false;
                btnAction.Visible = true;
                btnAddCourseCodes.Visible = true;
                cbxCourseCodes.Visible = true;
                btnAction.Text = "Delete";
            }
            else if (lblCreate.Enabled == false)
            {
                lblDelete.Text = "Delete";
                lblCreate.Enabled = true;
                lblUpdate.Enabled = true;
                txtSearch.Enabled = true;
                btnAction.Visible = false;
                btnAddCourseCodes.Visible = false;
                cbxCourseCodes.Visible = false;
                btnAction.Text = "--";
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
            //if (dgvStudent.Rows.Count > 0)
            //{
            //    dgvStudent.ClearSelection();
            //    dgvStudent.Rows[0].Selected = true;

            //}

            int desiredRowIndex = 0; // Replace with the index of the row you want to set focus to

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvStudent.Rows.Count)
            {
                // Set the focus to the desired row and select its first cell
                dgvStudent.CurrentCell = dgvStudent.Rows[desiredRowIndex].Cells[0];

                // Optionally, scroll to the selected row
                dgvStudent.FirstDisplayedScrollingRowIndex = desiredRowIndex;
            }



            int desiredIndex = dgvStudent.CurrentRow.Index; // Replace with the index of the item you want to highlight

            if (desiredIndex >= 0 && desiredIndex < lvStudent.Items.Count)
            {
                // Deselect all items first
                foreach (ListViewItem item in lvStudent.Items)
                {
                    item.Selected = false;
                }

                // Highlight the desired row
                lvStudent.Items[desiredIndex].Selected = true;

                // Ensure the highlighted item is visible
                lvStudent.Items[desiredIndex].EnsureVisible();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            //if (dgvStudent.Rows.Count > 0)
            //{
            //    currentRowIndex--;
            //    if (currentRowIndex < 0)
            //    {
            //        currentRowIndex = dgvStudent.Rows.Count - 1;
            //    }
            //    dgvStudent.ClearSelection();
            //    dgvStudent.Rows[currentRowIndex].Selected = true;
            //}

            int desiredRowIndex = dgvStudent.CurrentRow.Index - 1; // Replace with the index of the row you want to set focus to

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvStudent.Rows.Count)
            {
                // Set the focus to the desired row and select its first cell
                dgvStudent.CurrentCell = dgvStudent.Rows[desiredRowIndex].Cells[0];

                // Optionally, scroll to the selected row
                dgvStudent.FirstDisplayedScrollingRowIndex = desiredRowIndex;
            }



            int desiredIndex = dgvStudent.CurrentRow.Index; // Replace with the index of the item you want to highlight

            if (desiredIndex >= 0 && desiredIndex < lvStudent.Items.Count)
            {
                // Deselect all items first
                foreach (ListViewItem item in lvStudent.Items)
                {
                    item.Selected = false;
                }

                // Highlight the desired row
                lvStudent.Items[desiredIndex].Selected = true;

                // Ensure the highlighted item is visible
                lvStudent.Items[desiredIndex].EnsureVisible();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //if (currentRowIndex < dgvStudent.Rows.Count - 1)
            //{
            //    currentRowIndex++;
            //    dgvStudent.ClearSelection();
            //    dgvStudent.Rows[currentRowIndex].Selected = true;
            //}
            //else
            //{
            //    currentRowIndex = 0; // Must try and alter this so when going next from last row, it goes to first row (it goes to second row if clicked twice when at last row)
            //}
            int desiredRowIndex = dgvStudent.CurrentRow.Index+1; // Replace with the index of the row you want to set focus to

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvStudent.Rows.Count)
            {
                // Set the focus to the desired row and select its first cell
                dgvStudent.CurrentCell = dgvStudent.Rows[desiredRowIndex].Cells[0];

                // Optionally, scroll to the selected row
                dgvStudent.FirstDisplayedScrollingRowIndex = desiredRowIndex;
            }



            int desiredIndex = dgvStudent.CurrentRow.Index; // Replace with the index of the item you want to highlight

            if (desiredIndex >= 0 && desiredIndex < lvStudent.Items.Count)
            {
                // Deselect all items first
                foreach (ListViewItem item in lvStudent.Items)
                {
                    item.Selected = false;
                }

                // Highlight the desired row
                lvStudent.Items[desiredIndex].Selected = true;

                // Ensure the highlighted item is visible
                lvStudent.Items[desiredIndex].EnsureVisible();
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            //if (dgvStudent.Rows.Count > 0)
            //{
            //    dgvStudent.ClearSelection();

            //    int lastIndex = dgvStudent.Rows.Count - 1;
            //    dgvStudent.Rows[lastIndex].Selected = true;

            //}


            int desiredRowIndex = dgvStudent.RowCount-2; // Replace with the index of the row you want to set focus to

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvStudent.Rows.Count)
            {
                // Set the focus to the desired row and select its first cell
                dgvStudent.CurrentCell = dgvStudent.Rows[desiredRowIndex].Cells[0];

                // Optionally, scroll to the selected row
                dgvStudent.FirstDisplayedScrollingRowIndex = desiredRowIndex;
            }



            int desiredIndex = dgvStudent.CurrentRow.Index; // Replace with the index of the item you want to highlight

            if (desiredIndex >= 0 && desiredIndex < lvStudent.Items.Count)
            {
                // Deselect all items first
                foreach (ListViewItem item in lvStudent.Items)
                {
                    item.Selected = false;
                }

                // Highlight the desired row
                lvStudent.Items[desiredIndex].Selected = true;

                // Ensure the highlighted item is visible
                lvStudent.Items[desiredIndex].EnsureVisible();
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
            string name=txtName.Text;
            string surname=txtSurname.Text;
            string phone=txtPhone.Text;
            string adress=txtAdress.Text;
            string image=pbxStudent.BackgroundImage.ToString();
            string gender;
            if (rbFemale.Checked)
            {
                gender = "Female";
            }
            else
            {
                gender = "Male";
            }
            string moduleCodes = "PRG281";
            DateTime DOB=Date.Value.ToUniversalTime();
            Student student = new Student(name,surname,image,DOB,gender,phone,adress,moduleCodes);
            if (btnAction.Text.Equals("Delete"))
            {

                DataHandler.deleteStudent(int.Parse(lblStudentNr.Text));
                dgvStudent.DataSource = DataHandler.showStudentData();
                lblDelete.Text = "Delete";
                lblCreate.Enabled = true;
                lblUpdate.Enabled = true;
                txtSearch.Enabled = true;
                btnAction.Visible = false;
                btnAddCourseCodes.Visible = false;
                cbxCourseCodes.Visible = false;
                btnAction.Text = "--";
            }
            if (btnAction.Text.Equals("Update"))
            {
                
                DataHandler.updateStudent(student);
                dgvStudent.DataSource = DataHandler.showStudentData();
                lblUpdate.Text = "Update";
                lblCreate.Enabled = true;
                lblDelete.Enabled = true;
                txtSearch.Enabled = true;
                btnAction.Visible = false;
                btnAddCourseCodes.Visible = false;
                cbxCourseCodes.Visible = false;
                btnAction.Text = "--";

            }
            if (btnAction.Text.Equals("Create"))
            {
                
                DataHandler.createStudent(student);
                dgvStudent.DataSource = DataHandler.showStudentData();
                lblCreate.Text = "Create";
                lblUpdate.Enabled = true;
                lblDelete.Enabled = true;
                txtSearch.Enabled = true;
                btnAddCourseCodes.Visible = false;
                cbxCourseCodes.Visible = false;
                btnAction.Visible = false;
                btnAction.Text = "--";
                ;
            }
        }

        private void dgvStudent_CursorChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_CursorChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvStudent_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStudent.SelectedCells.Count > 0)
            {
                int rowIndex = dgvStudent.SelectedCells[0].RowIndex;

                // Assuming column indices for Name, Surname, Phone, Address, and Gender
                txtName.Text = dgvStudent.Rows[rowIndex].Cells["Name"].Value.ToString();
                txtSurname.Text = dgvStudent.Rows[rowIndex].Cells["Surname"].Value.ToString();
                txtPhone.Text = dgvStudent.Rows[rowIndex].Cells["Phone"].Value.ToString();
                txtAdress.Text = dgvStudent.Rows[rowIndex].Cells["Address"].Value.ToString();

                string gender = dgvStudent.Rows[rowIndex].Cells["Gender"].Value.ToString();
                if (gender == "Male")
                {
                    rbMale.Checked = true;
                }
                else
                {
                    rbFemale.Checked = true;
                }
            }
        }
    }
}
