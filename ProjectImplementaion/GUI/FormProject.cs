using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectImplementaion
{
    public partial class FormProject : Form
    {
        ProjectModel projectContext;
        public FormProject()
        {
            InitializeComponent();
        }
        public FormProject(ProjectModel projectContext)
        {
            InitializeComponent();
            this.projectContext = projectContext;
            projectContext.Projects.Load();
            projectContext.Customers.Load();
            projectContext.Categories.Load();
            projectBindingSource.DataSource = projectContext.Projects.Local.ToBindingList();//.Local.ToBindingList();
            customerBindingSource.DataSource = projectContext.Customers.Local.ToBindingList();
            categoryBindingSource.DataSource = projectContext.Categories.Local.ToBindingList();
        }
        private void projectBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {





            performersBindingSource.EndEdit();
            projectBindingSource.EndEdit();

            projectContext.SaveChanges();
            performersListBox.Refresh();
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
            categoryComboBox.SelectedIndex = -1;
            customerComboBox.SelectedIndex = -1;
            dateStartDateTimePicker.Value = DateTime.Today.Date;
        }

        private void buttonRemovePerformer_Click(object sender, EventArgs e)
        {
            if(performersListBox.SelectedIndex>=0)
            {
                performersListBox.Items.Remove(performersListBox.SelectedItem);
            }
        }

        private void buttonAddPerformer_Click(object sender, EventArgs e)
        {
          Project currentProgect=  projectBindingSource.Current as Project;
            FormPerformersForProject formPerformersForProject = new FormPerformersForProject(projectContext, currentProgect);
            if (formPerformersForProject.ShowDialog() == DialogResult.OK)
            {

                currentProgect.Performers.Add(new Performer { ProjectId = currentProgect.Id, EmployeeId = (formPerformersForProject.performerForProjectBindingSource.Current as PerformerForProject).EmployeeId });
                projectBindingNavigatorSaveItem_Click(projectBindingNavigatorSaveItem, new EventArgs());
                int pos = projectBindingSource.Position;
                projectBindingSource.Position = projectBindingSource.Count-1;
                projectBindingSource.Position = pos;

                
            }
        }

        private void projectBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void projectBindingSource_PositionChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }
    }
}
