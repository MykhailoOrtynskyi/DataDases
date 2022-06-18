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
    public partial class FormPerformersForProject : Form
    {

        ProjectModel projectContext;
        public FormPerformersForProject()
        {
            InitializeComponent();
        }
        public FormPerformersForProject(ProjectModel projectContext, Project project)
        {
            InitializeComponent();
            this.projectContext = projectContext;
            performerForProjectBindingSource.DataSource = projectContext.PerformerForProjects(project).ToList();
        }
    }
}
