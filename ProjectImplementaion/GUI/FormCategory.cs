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
    public partial class FormCategory : Form
    {
        ProjectModel projectContext;
        public FormCategory()
        {
            InitializeComponent();
        }
        public FormCategory(ProjectModel projectContext)
        {
            InitializeComponent();
            this.projectContext = projectContext;
            projectContext.Categories.Load();
            categoryBindingSource.DataSource = projectContext.Categories.Local.ToBindingList();
        }
        

        private void positionBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
           

            toolStripStatusLabel1.Text = "";
            categoryDataGridView.EndEdit();
            categoryBindingSource.EndEdit();
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

        private void positionDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void categoryBindingSource_PositionChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }
    }
}
