namespace ProjectImplementaion
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Data.Common;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProjectModel : DbContext
    {
        public ProjectModel()
            : base("name=ProjectModel")
        {
        }
        public ProjectModel(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
            
        }
        public ProjectModel(string nameConnectionString)
       : base(nameConnectionString)
        {}
        public virtual DbSet<Career> Careers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Performer> Performers { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Qualifiction> Qualifictions { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
        //public virtual DbSet<ProjectsFinancialReport> ProjectsFinancialReports { get; set; }

        public IEnumerable<ProjectsFinancialReport> ProjectsFinancialReports
        {
            get
            {
                return Database.SqlQuery<ProjectsFinancialReport>("PROJECTS_REPORT");
            }
        }

        public IEnumerable<PerformerForProject> PerformerForProjects(Project project)
        {
            SqlParameter sqlParameterProjectId = new SqlParameter("@progectId", project.Id);
                return Database.SqlQuery<PerformerForProject>("PERFORMERS_FOR_PROJECT @progectId",sqlParameterProjectId);
           
        }
        public IEnumerable<SalaryByPeriod> SalaryByPeriod(DateTime dateStart, DateTime dateEnd)
        {
            SqlParameter sqlParameterdateStart = new SqlParameter("@dateStart", dateStart.Date);
            SqlParameter sqlParameterdateEnd = new SqlParameter("@dateEnd", dateEnd.Date);
            return Database.SqlQuery<SalaryByPeriod>("SALARY_BY_PERIOD_QUALIFICATION_POSITION @dateStart, @dateEnd", sqlParameterdateStart,sqlParameterdateEnd);

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //if (IsMigration)
            modelBuilder.Ignore<ProjectsFinancialReport>();
            modelBuilder.Ignore<PerformerForProject>();
            modelBuilder.Ignore<SalaryByPeriod>();

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Projects)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Projects)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Careers)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Performers)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Salaries)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Sum)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Performer>()
                .HasMany(e => e.Reports)
                .WithRequired(e => e.Performer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Position>()
                .HasMany(e => e.Careers)
                .WithRequired(e => e.Position)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Performers)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Qualifiction>()
                .Property(e => e.HourleRate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Qualifiction>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Qualifiction)
                .HasForeignKey(e => e.QualificationId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Salary>()
                .Property(e => e.Sum)
                .HasPrecision(19, 4);
        }
    }
}
