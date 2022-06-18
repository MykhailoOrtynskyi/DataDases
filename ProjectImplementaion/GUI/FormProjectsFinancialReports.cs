using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectImplementaion
{
    public partial class FormProjectsFinancialReports : Form
    {
        ProjectModel projectContext;
        public FormProjectsFinancialReports(ProjectModel projectContext)
        {
            InitializeComponent();
            this.projectContext = projectContext;
            projectsFinancialReportBindingSource.DataSource = projectContext.ProjectsFinancialReports.ToList();
            //salaryBindingSource.DataSource = projectContext.Salaries.Local.ToBindingList();
        }
    }
}
