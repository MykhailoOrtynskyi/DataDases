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
    public partial class FormQualifiction : Form
    {
        ProjectModel projectContext;
        public FormQualifiction()
        {
            InitializeComponent();
        }
        public FormQualifiction(ProjectModel projectContext)
        {
            InitializeComponent();
            this.projectContext = projectContext;
            projectContext.Qualifictions.Load();
            qualifictionBindingSource.DataSource = projectContext.Qualifictions.Local.ToBindingList();
            //qualifictionBindingSource.DataSource = projectContext.Qualifictions.ToList();
        }
      
        private void qualifictionBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            

            toolStripStatusLabel1.Text = "";
            qualifictionDataGridView.EndEdit();
            qualifictionBindingSource.EndEdit();

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

        private void qualifictionBindingSource_PositionChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }
    }
}
