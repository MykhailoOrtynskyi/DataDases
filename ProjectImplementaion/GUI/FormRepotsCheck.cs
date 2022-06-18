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
    public partial class FormRepotsCheck : Form
    {
        ProjectModel projectContext;
        public FormRepotsCheck()
        {
            InitializeComponent();
        }

        public FormRepotsCheck(ProjectModel projectContext)
        {
            this.projectContext = projectContext;
            InitializeComponent();
            Load += FormRepotsCheck_Load;

        }

        private void FormRepotsCheck_Load(object sender, EventArgs e)
        {
            try
            {
                projectContext.Reports.Load();
                reportsBindingSource.DataSource = projectContext.Reports.Local.ToBindingList();

                projectContext.Projects.Load();
                projectBindingSource.DataSource = projectContext.Projects.Local.ToBindingList();
                projectComboBox.SelectedIndexChanged += ProjectComboBox_SelectedIndexChanged;
                projectComboBox.SelectedIndex = -1;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Дана опція не доступна для вас");
                this.Close();
            }




        }

        private void ProjectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            reportsBindingSource.DataSource = projectContext.Reports.Local.Where(report => report.Performer.Project == projectComboBox.SelectedItem).ToList();
        }

        private void performerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

            toolStripStatusLabel1.Text = "";
            reportsDataGridView.EndEdit();
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

        private void reportsBindingSource_PositionChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
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
