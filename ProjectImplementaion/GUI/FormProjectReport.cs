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
    public partial class FormProjectReport : Form
    {
        ProjectModel projectContext;
        public FormProjectReport(ProjectModel projectContext)
        {
            this.projectContext = projectContext;
            InitializeComponent();
            Load += FormProjectReport_Load;
        }

        private void FormProjectReport_Load(object sender, EventArgs e)
        {
            projectContext.Reports.Load();
            reportBindingSource.DataSource = projectContext.Reports.Local.ToBindingList();

            projectContext.Projects.Load();
            projectBindingSource.DataSource = projectContext.Projects.Local.ToBindingList();
            projectComboBox.SelectedIndexChanged += ProjectComboBox_SelectedIndexChanged; ;
            projectComboBox.SelectedIndex = -1;
            dateTimePickerFrom.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dateTimePickerTo.Value = dateTimePickerFrom.Value.Date.AddMonths(1).AddDays(-1);
        }


        void SetDataSource()
        {
            reportBindingSource.DataSource = projectContext.Reports.Local.
               Where
               (
               report => report.Performer.Project == projectComboBox.SelectedItem
               && report.Date >= dateTimePickerFrom.Value.Date
               && report.Date <= dateTimePickerTo.Value.Date
               ).ToList();
        }
        private void ProjectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDataSource();
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            SetDataSource();
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            SetDataSource();
        }
    }
}
