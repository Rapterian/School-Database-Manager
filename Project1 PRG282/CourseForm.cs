using Project1_PRG282.DataAccess;

using Project1_PRG282.LogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Project1_PRG282.LogicLayer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project1_PRG282
{
    public partial class CourseForm : Form
    {
        public CourseForm()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {

        }

        int createCounter = 0;
        private void lblCreate_Click(object sender, EventArgs e)
        {
            createCounter++;
            if (createCounter == 1)
            {
                lblUpdate.Enabled = false;
                lblDelete.Enabled = false;
                txtSearch.Enabled = false;
                btnAction.Text = "Create";
                btnAction.Visible = true;
                txtModuleName.Text = "";
                txtModuleCode.Text = "";
                rtbxCourseDescription.Clear();
            }
            else if (createCounter > 1)
            {
                lblUpdate.Enabled = true;
                lblDelete.Enabled = true;
                txtSearch.Enabled = true;
                btnAction.Visible = false;
                btnAction.Text = "--";
                createCounter = 0;
            }
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
                btnAction.Text = "Delete";
                btnAction.Visible = true;
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

        private void CourseForm_Load(object sender, EventArgs e)
        {
            //This is for the DataGridView
            dgvModule.DataSource = DataHandler.showModuleData();

            //This is for the list view
            foreach (DataRow row in DataHandler.showModuleData().Rows)
            {
                ListViewItem item = new ListViewItem(row["ModuleCode"].ToString());
                item.SubItems.Add(row["ModuleName"].ToString());
                item.SubItems.Add(row["ModuleDescription"].ToString());
                item.SubItems.Add(row["Links"].ToString());
                lvModule.Items.Add(item);
            }
        }

        private void CourseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        int currentRowIndex = 0;
        private void btnStart_Click(object sender, EventArgs e)
        {
            //if (dgvModule.Rows.Count > 0)
            //{
            //    dgvModule.ClearSelection();
            //    dgvModule.Rows[0].Selected = true;
            //}
            int desiredRowIndex = 0; // Replace with the index of the row you want to set focus to

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvModule.Rows.Count)
            {
                // Set the focus to the desired row and select its first cell
                dgvModule.CurrentCell = dgvModule.Rows[desiredRowIndex].Cells[0];

                // Optionally, scroll to the selected row
                dgvModule.FirstDisplayedScrollingRowIndex = desiredRowIndex;
            }

            int desiredIndex = dgvModule.CurrentRow.Index; // Replace with the index of the item you want to highlight

            if (desiredIndex >= 0 && desiredIndex < lvModule.Items.Count)
            {
                // Deselect all items first
                foreach (ListViewItem item in lvModule.Items)
                {
                    item.Selected = false;
                }

                // Highlight the desired row
                lvModule.Items[desiredIndex].Selected = true;

                // Ensure the highlighted item is visible
                lvModule.Items[desiredIndex].EnsureVisible();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            //if (dgvModule.Rows.Count > 0)
            //{
            //    currentRowIndex--;
            //    if (currentRowIndex < 0)
            //    {
            //        currentRowIndex = dgvModule.Rows.Count - 1;
            //    }
            //    dgvModule.ClearSelection();
            //    dgvModule.Rows[currentRowIndex].Selected = true;
            //}
            int desiredRowIndex = dgvModule.CurrentRow.Index - 1; // Replace with the index of the row you want to set focus to

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvModule.Rows.Count)
            {
                // Set the focus to the desired row and select its first cell
                dgvModule.CurrentCell = dgvModule.Rows[desiredRowIndex].Cells[0];

                // Optionally, scroll to the selected row
                dgvModule.FirstDisplayedScrollingRowIndex = desiredRowIndex;
            }

            int desiredIndex = dgvModule.CurrentRow.Index; // Replace with the index of the item you want to highlight

            if (desiredIndex >= 0 && desiredIndex < lvModule.Items.Count)
            {
                // Deselect all items first
                foreach (ListViewItem item in lvModule.Items)
                {
                    item.Selected = false;
                }

                // Highlight the desired row
                lvModule.Items[desiredIndex].Selected = true;

                // Ensure the highlighted item is visible
                lvModule.Items[desiredIndex].EnsureVisible();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //if (currentRowIndex < dgvModule.Rows.Count - 1)
            //{
            //    currentRowIndex++;
            //    dgvModule.ClearSelection();
            //    dgvModule.Rows[currentRowIndex].Selected = true;
            //}
            //else
            //{
            //    currentRowIndex = 0; // Must try and alter this so when going next from last row, it goes to first row (it goes to second row if clicked twice when at last row)
            //}
            int desiredRowIndex = dgvModule.CurrentRow.Index + 1; // Replace with the index of the row you want to set focus to

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvModule.Rows.Count)
            {
                // Set the focus to the desired row and select its first cell
                dgvModule.CurrentCell = dgvModule.Rows[desiredRowIndex].Cells[0];

                // Optionally, scroll to the selected row
                dgvModule.FirstDisplayedScrollingRowIndex = desiredRowIndex;
            }

            int desiredIndex = dgvModule.CurrentRow.Index; // Replace with the index of the item you want to highlight

            if (desiredIndex >= 0 && desiredIndex < lvModule.Items.Count)
            {
                // Deselect all items first
                foreach (ListViewItem item in lvModule.Items)
                {
                    item.Selected = false;
                }

                // Highlight the desired row
                lvModule.Items[desiredIndex].Selected = true;

                // Ensure the highlighted item is visible
                lvModule.Items[desiredIndex].EnsureVisible();
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            //if (dgvModule.Rows.Count > 0)
            //{
            //    dgvModule.ClearSelection();

            //    int lastIndex = dgvModule.Rows.Count - 1;
            //    dgvModule.Rows[lastIndex].Selected = true;

            //}
            int desiredRowIndex = dgvModule.RowCount-2; // Replace with the index of the row you want to set focus to

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvModule.Rows.Count)
            {
                // Set the focus to the desired row and select its first cell
                dgvModule.CurrentCell = dgvModule.Rows[desiredRowIndex].Cells[0];

                // Optionally, scroll to the selected row
                dgvModule.FirstDisplayedScrollingRowIndex = desiredRowIndex;
            }

            int desiredIndex = dgvModule.CurrentRow.Index; // Replace with the index of the item you want to highlight

            if (desiredIndex >= 0 && desiredIndex < lvModule.Items.Count)
            {
                // Deselect all items first
                foreach (ListViewItem item in lvModule.Items)
                {
                    item.Selected = false;
                }

                // Highlight the desired row
                lvModule.Items[desiredIndex].Selected = true;

                // Ensure the highlighted item is visible
                lvModule.Items[desiredIndex].EnsureVisible();
            }
        }

        private void lvModule_MouseClick(object sender, MouseEventArgs e)
        {
            txtModuleCode.Text = lvModule.SelectedItems[0].SubItems[0].Text;
            txtModuleName.Text = lvModule.SelectedItems[0].SubItems[1].Text;
            rtbxCourseDescription.Text = lvModule.SelectedItems[0].SubItems[2].Text;


            int desiredRowIndex = lvModule.SelectedIndices[0]; // Replace with the index of the row you want to set focus to

            if (desiredRowIndex >= 0 && desiredRowIndex < dgvModule.Rows.Count)
            {
                // Set the focus to the desired row and select its first cell
                dgvModule.CurrentCell = dgvModule.Rows[desiredRowIndex].Cells[0];

                // Optionally, scroll to the selected row
                dgvModule.FirstDisplayedScrollingRowIndex = desiredRowIndex;
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (btnAction.Text == "Create")
            {
                try
                {
                    Module module = new Module();

                    DataHandler.createModule(module);

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
                    Module module = new Module();

                    DataHandler.updateModule(module);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (btnAction.Text == "Delete")
            {
                int number = int.Parse(txtModuleCode.Text);

                DataHandler.deleteModule(number);
            }
        }

        private void dgvModule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{

            //    DataGridViewRow row = this.dgvModule.Rows[e.RowIndex];

            //    txtModuleCode.Text = row.Cells["ModuleCode"].Value.ToString();
            //    txtModuleName.Text = row.Cells["ModuleName"].Value.ToString();
            //    rtbxCourseDescription.Text = row.Cells["ModuleDescription"].Value.ToString();
            //    rtbxYoutubeLinks.Text = row.Cells["Links"].Value.ToString();  
            //}
        }

        private void dgvModule_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dgvModule.Rows[e.RowIndex];

                txtModuleCode.Text = row.Cells["ModuleCode"].Value.ToString();
                txtModuleName.Text = row.Cells["ModuleName"].Value.ToString();
                rtbxCourseDescription.Text = row.Cells["ModuleDescription"].Value.ToString();
                rtbxYoutubeLinks.Text = row.Cells["Links"].Value.ToString();
            }
        }
    }
}
