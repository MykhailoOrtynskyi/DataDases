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
    public partial class FormCustomer : Form
    {
        ProjectModel projectContext;
        public FormCustomer()
        {
            InitializeComponent();
        }
        public FormCustomer(ProjectModel projectContext)
        {
            InitializeComponent();
            this.projectContext = projectContext;
            projectContext.Customers.Load();
            customerBindingSource.DataSource = projectContext.Customers.Local.ToBindingList();
        }
        private void customerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            


            toolStripStatusLabel1.Text = "";
            customerDataGridView.EndEdit();
            customerBindingSource.EndEdit();
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

        private void customerBindingSource_PositionChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }
    }
}
