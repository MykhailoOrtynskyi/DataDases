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
    public partial class ReportForm : Form
    {
        ProjectModel projectContext;
        public ReportForm()
        {
            InitializeComponent();
        }

        public ReportForm(ProjectModel projectContext)
        {
            this.projectContext = projectContext;
            InitializeComponent();
            Load += ReportForm_Load;
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            
            
                projectContext.Projects.Load();
                projectBindingSource.DataSource = projectContext.Projects.Local.ToBindingList();
            
           
        }

        private void projectBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
            reportsDataGridView.EndEdit();
            try
            {

                projectContext.SaveChanges();
                toolStripStatusLabel2.Text = "Дані успішно збережено";
        }
            catch(Exception exception)
            {
                //MessageBox.Show(exception.Message);
                MessageBox.Show(exception.InnerException.InnerException.Message);
            }

    //System.Data.SqlClient.SqlException
}

        private void ReportForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
