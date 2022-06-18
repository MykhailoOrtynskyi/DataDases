using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectImplementaion
{
    
    public partial class MainForm : Form
    {
        ProjectModel projectContext;
        public MainForm()
        {
            InitializeComponent();
            projectContext = new ProjectModel();
            LoadData();
            Shown += MainForm_Shown;
            //projectContext = new ProjectModel();
            
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            AutentificationForm autentificationForm = new AutentificationForm();
            autentificationForm.StartPosition = FormStartPosition.CenterParent;
            do
            {
                if (autentificationForm.ShowDialog() == DialogResult.OK)
                {
                    string login = autentificationForm.textBox1.Text;
                    string password = autentificationForm.textBox2.Text;
                    SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
                    sqlConnectionStringBuilder["data source"] = @"DESKTOP-CRTP7AS\SQLEXPRESS";
                    sqlConnectionStringBuilder["initial catalog"] = @"ProjectImplementation";
                    sqlConnectionStringBuilder["data source"] = @"DESKTOP-CRTP7AS\SQLEXPRESS";
                    sqlConnectionStringBuilder["integrated security"] = @"False";
                    sqlConnectionStringBuilder["User ID"] =login;
                    sqlConnectionStringBuilder["Password"] = password;
                    
                    SqlConnection dbConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

                    try
                    {
                        dbConnection.Open();
                        //LoadData();
                        //projectContext = new ProjectModel(dbConnection, false);
                        EnableData(login);

                        
                        break;
                    }
                    catch (Exception exc)
                    {
                        autentificationForm.errorProvider1.SetError(autentificationForm.textBox1, "Невірний логін або пароль");
                        autentificationForm.errorProvider1.SetError(autentificationForm.textBox2, "Невірний логін або пароль");
                        continue;
                    }
                   
                }
                else
                {
                    this.Close();
                    break;
                }
            }
            while (true);
        }

        private void EnableData(string login)
        {
            if(login=="Simple")
            {
                довідникиToolStripMenuItem.Enabled = false;
                перевіркаЗвітуToolStripMenuItem.Enabled = false;
                фінансовийЗвітПоПроектазToolStripMenuItem.Enabled = false;
                працівникToolStripMenuItem.Enabled = false;
                проектToolStripMenuItem.Enabled = false;
            }
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm(projectContext);
            reportForm.ShowDialog();
        }

        private void перевіркаЗвітуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRepotsCheck formRepotsCheck = new FormRepotsCheck(projectContext);
            formRepotsCheck.ShowDialog();
        }

        private void звітПоПроектуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProjectReport formProjectReport = new FormProjectReport(projectContext);
            formProjectReport.ShowDialog();
        }

        private void зарплатаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSalary formSalary = new FormSalary(projectContext);
            formSalary.ShowDialog();
        }

        private void фінансовийЗвітПоПроектазToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProjectsFinancialReports formProjectsFinancialReports = new FormProjectsFinancialReports(projectContext);
            formProjectsFinancialReports.ShowDialog();
        }

        private void створенняредагуванняПроектуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProject formProject = new FormProject(projectContext);
            formProject.ShowDialog();
        }

        private void замовникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCustomer formCustomer = new FormCustomer(projectContext);
            formCustomer.ShowDialog();
        }

        private void рухункиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOrder formOrder = new FormOrder(projectContext);
            formOrder.ShowDialog();
        }

        private void посадиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPosition formPosition = new FormPosition(projectContext);
            formPosition.ShowDialog();
        }

        private void кваліфікаціїToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormQualifiction formQualifiction = new FormQualifiction(projectContext);
            formQualifiction.ShowDialog();
        }

        private void LoadData()
        {
           
            projectContext.Qualifictions.Load();
            projectContext.Customers.Load();
            projectContext.Positions.Load();
            projectContext.Projects.Load();
            projectContext.Categories.Load();
        }

        private void категоріїПроектівToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCategory formCategory = new FormCategory(projectContext);
            formCategory.ShowDialog();
        }

        private void облікПрацівниківToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEmployee formEmployee = new FormEmployee(projectContext);
            formEmployee.ShowDialog();
        }
    }
}
