using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace ProjectImplementaion
{
    public partial class FormEmployee : Form
    {
        ProjectModel projectContext;
        public FormEmployee()
        {
            InitializeComponent();
        }

        public FormEmployee(ProjectModel projectContext)
        {
            InitializeComponent();
            this.projectContext = projectContext;
            projectContext.Employees.Load();
            projectContext.Qualifictions.Load();
            projectContext.Positions.Load();
            employeeBindingSource.DataSource = projectContext.Employees.Local.ToBindingList();
            qualifictionBindingSource.DataSource = projectContext.Qualifictions.Local.ToBindingList();
            positionBindingSource.DataSource = projectContext.Positions.Local.ToBindingList();
        }

        private void employeeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            

            toolStripStatusLabel1.Text = "";
            employeeBindingSource.EndEdit();
            projectContext.SaveChanges();
            
            try
            {

                projectContext.SaveChanges();
                toolStripStatusLabel1.Text = "Дані успішно збережено";
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message);
                MessageBox.Show(exception.InnerException.InnerException.Message);
            }
        }

        private void employeeBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            

            toolStripStatusLabel1.Text = "";
            careersDataGridView.EndEdit();
            careersBindingSource.EndEdit();
            projectContext.SaveChanges();

            try
            {

                projectContext.SaveChanges();
                toolStripStatusLabel1.Text = "Дані успішно збережено";
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message);
                MessageBox.Show(exception.InnerException.InnerException.Message);
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            fullNameTextBox.Text = "";
            qualifictionComboBox.SelectedIndex = -1;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            positionComboBox.SelectedIndex = -1;
            dateStartDateTimePicker.Value = DateTime.Today.Date;
            dateEndDateTimePicker.Value = dateStartDateTimePicker.Value.AddDays(365).Date;
        }

        private void employeeBindingSource_PositionChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void careersBindingSource_PositionChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }
    }
}
