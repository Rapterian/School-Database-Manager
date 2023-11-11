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
using System.Reflection;

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

            lblUpdate.Text = "Cancel";
            lblCreate.Enabled = false;
            lblDelete.Enabled = false;
            lblCreate.Visible = false;
            lblDelete.Visible = false;

            btnAction.Text = "Create";

            txtAdress.Enabled = true;
            txtName.Enabled = true;
            txtPhone.Enabled = true;
            txtSearch.Enabled = true;
            txtSurname.Enabled = true;
            Date.Enabled = true;
            gbGender.Enabled = true;

            btnAction.Visible = true;
            txtAdress.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtSearch.Text = "";
            txtSurname.Text = "";
            cbxCourseCodes.Visible = true;
            btnAddCourseCodes.Visible = true;
            txtName.Focus();
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
                lblCreate.Visible = false;
                lblDelete.Visible = false;

                btnAction.Text = "Update";
                btnAction.Visible = true;

                txtAdress.Enabled = true;
                txtName.Enabled = true;
                txtPhone.Enabled = true;
                txtSearch.Enabled = true;
                txtSurname.Enabled = true;
                Date.Enabled = true;
                gbGender.Enabled = true;
                cbxCourseCodes.Visible = true;
                btnAddCourseCodes.Visible = true;
            }
            else if (lblUpdate.Text.Equals("Cancel"))
            {
                lblUpdate.Text = "Update";
                lblCreate.Enabled = true;
                lblDelete.Enabled = true;
                lblCreate.Visible = true;
                lblDelete.Visible = true;
                btnAction.Visible = true;
                cbxCourseCodes.Visible = false;
                btnAddCourseCodes.Visible = false;
                btnAction.Text = "--";

                txtAdress.Enabled = false;
                txtName.Enabled = false;
                txtPhone.Enabled = false;
                txtSurname.Enabled = false;
                Date.Enabled = false;
                gbGender.Enabled = false;
            }
        }

        private void lblDelete_Click(object sender, EventArgs e)
        {

            lblUpdate.Text = "Cancel";
            lblCreate.Enabled = false;
            lblDelete.Enabled = false;
            lblCreate.Visible = false;
            lblDelete.Visible = false;
            btnAction.Visible = true;
            btnAction.Text = "Delete";

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

            int desiredRowIndex = dgvStudent.CurrentRow.Index + 1; // Replace with the index of the row you want to set focus to

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
            int desiredRowIndex = dgvStudent.RowCount - 2; // Replace with the index of the row you want to set focus to

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
            }
            else
            {
                rbFemale.Checked = true;
            }

            int desiredRowIndex = lvStudent.SelectedIndices[0]; // Replace with the index of the row you want to set focus to

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvStudent.Rows.Count)
            {
                // Set the focus to the desired row and select its first cell
                dgvStudent.CurrentCell = dgvStudent.Rows[desiredRowIndex].Cells[0];

                // Optionally, scroll to the selected row
                dgvStudent.FirstDisplayedScrollingRowIndex = desiredRowIndex;
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (btnAction.Text == "Create")
            {
                try
                {
                    Student student = new Student();

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
                    Student student = new Student();

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
            //if (e.RowIndex >= 0)
            //{

            //    DataGridViewRow row = this.dgvStudent.Rows[e.RowIndex];

            //    txtName.Text = row.Cells["Name"].Value.ToString();
            //    txtSurname.Text = row.Cells["Surname"].Value.ToString();
            //    txtPhone.Text = row.Cells["Phone"].Value.ToString();
            //    txtAdress.Text = row.Cells["Address"].Value.ToString();
            //    rtbxCourseCodes.Text = row.Cells["ModuleCode"].Value.ToString();
            //}
        }

        private void dgvStudent_RowEnter(object sender, DataGridViewCellEventArgs e)
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
