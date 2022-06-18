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
    public partial class FormPosition : Form
    {
        ProjectModel projectContext;
        public FormPosition()
        {
            InitializeComponent();
        }
        public FormPosition(ProjectModel projectContext)
        {
            InitializeComponent();
            this.projectContext = projectContext;
            projectContext.Positions.Load();
            positionBindingSource.DataSource = projectContext.Positions.Local.ToBindingList();
        }
        

        private void positionBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            

            toolStripStatusLabel1.Text = "";
            positionBindingSource.EndEdit();
            positionDataGridView.EndEdit();
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

        private void positionBindingSource_PositionChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }
    }
}
