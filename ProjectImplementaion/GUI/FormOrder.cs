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
using System.Data.Sql;
using System.Data.SqlClient;

namespace ProjectImplementaion
{
    public partial class FormOrder : Form
    {
        ProjectModel projectContext;
        public FormOrder(ProjectModel projectContext)
        {
            InitializeComponent();
          
            Load += FormOrder_Load;
            this.projectContext = projectContext;
           
            orderBindingSource.DataSourceChanged += OrderBindingSource_DataSourceChanged;
            
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            dateTimePickerFrom.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dateTimePickerTo.Value = dateTimePickerFrom.Value.Date.AddMonths(1).AddDays(-1);
        }

        private void OrderBindingSource_DataSourceChanged(object sender, EventArgs e)
        {
            if (orderBindingSource.Count != 0)
                buttonGenerateOrder.Enabled = false;
            else
                buttonGenerateOrder.Enabled = true;
        }

        void SetDataSource()
        {
            orderBindingSource.DataSource = projectContext.Orders.Where(order=>order.DateStart>=dateTimePickerFrom.Value.Date && order.DateEnd<=dateTimePickerTo.Value.Date).ToList(); ;
        }
        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            SetDataSource();
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            SetDataSource();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dateStart = dateTimePickerFrom.Value.Date;
            DateTime dateEnd = dateTimePickerTo.Value.Date;

            SqlParameter sqlParameterFrom = new SqlParameter("@dateStart", dateStart);
            SqlParameter sqlParameterTo = new SqlParameter("@dateEnd", dateEnd);
            projectContext.Database.ExecuteSqlCommand("GenarateOrder  @dateStart, @dateEnd", sqlParameterFrom, sqlParameterTo);
            SetDataSource();
        }

        private void performerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            orderDataGridView.EndEdit();
            orderBindingSource.EndEdit();
            projectContext.SaveChanges();
        }
    }
    }

