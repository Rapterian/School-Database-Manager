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
            if (dgvModule.Rows.Count > 0)
            {
                dgvModule.ClearSelection();
                dgvModule.Rows[0].Selected = true;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (dgvModule.Rows.Count > 0)
            {
                currentRowIndex--;
                if (currentRowIndex < 0)
                {
                    currentRowIndex = dgvModule.Rows.Count - 1;
                }
                dgvModule.ClearSelection();
                dgvModule.Rows[currentRowIndex].Selected = true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentRowIndex < dgvModule.Rows.Count - 1)
            {
                currentRowIndex++;
                dgvModule.ClearSelection();
                dgvModule.Rows[currentRowIndex].Selected = true;
            }
            else
            {
                currentRowIndex = 0; // Must try and alter this so when going next from last row, it goes to first row (it goes to second row if clicked twice when at last row)
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (dgvModule.Rows.Count > 0)
            {
                dgvModule.ClearSelection();

                int lastIndex = dgvModule.Rows.Count - 1;
                dgvModule.Rows[lastIndex].Selected = true;

            }
        }

        private void lvModule_MouseClick(object sender, MouseEventArgs e)
        {
            txtModuleCode.Text = lvModule.SelectedItems[0].SubItems[0].Text;
            txtModuleName.Text = lvModule.SelectedItems[0].SubItems[1].Text;
            rtbxCourseDescription.Text = lvModule.SelectedItems[0].SubItems[2].Text;
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (btnAction.Text == "Create")
            {
                try
                {
                    Module module = new Module("Dont know what to put here");

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
                    Module module = new Module("Dont know what to put here");

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
    }
}
