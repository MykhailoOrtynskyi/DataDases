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
    public partial class FormSalary : Form
    {
        ProjectModel projectContext;
        public FormSalary(ProjectModel projectContext)
        {
            InitializeComponent();
          
            Load += FormSalary_Load;
            this.projectContext = projectContext;
           
            salaryByPeriodBindingSource.DataSourceChanged += SalaryBindingSource_DataSourceChanged;
            
        }

        private void FormSalary_Load(object sender, EventArgs e)
        {
            dateTimePickerFrom.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dateTimePickerTo.Value = dateTimePickerFrom.Value.Date.AddMonths(1).AddDays(-1);
        }

        private void SalaryBindingSource_DataSourceChanged(object sender, EventArgs e)
        {
            if (salaryByPeriodBindingSource.Count != 0)
                buttonGenerateSalary.Enabled = false;
            else
                buttonGenerateSalary.Enabled = true;
        }

        void SetDataSource()
        {
            salaryByPeriodBindingSource.DataSource = projectContext.SalaryByPeriod(dateTimePickerFrom.Value.Date, dateTimePickerTo.Value.Date).ToList();
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
            projectContext.Database.ExecuteSqlCommand("GenarateSalary  @dateStart, @dateEnd", sqlParameterFrom, sqlParameterTo);
            SetDataSource();
        }
    }
    }

