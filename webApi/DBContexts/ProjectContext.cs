using Microsoft.EntityFrameworkCore;
using webApi.Models;

namespace webApi.DBContexts
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Project_Employee> Projects_Employee { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Projects>().HasData(

            new Projects
            {
                Id = 1,
                ProjectName = "My Assignment",
                ClintName = "Test Clint",
                InitiationDate = "12-02-03",
                duration = " 01-01-2022",
            },

           new Projects
           {
               Id = 2,
               ProjectName = "My Assignment2",
               ClintName = "Test Clint2",
               InitiationDate = "12-02-03",
               duration = " 02-01-2022",
           }
           ,
           new Projects
           {
               Id = 3,
               ProjectName = "My Assignment3",
               ClintName = "Test Clint3",
               InitiationDate = "12-02-03",
               duration = " 03-01-2022",

           });
            modelBuilder.Entity<Employees>().HasData(
           new Employees
           {
               Id = 4,
               firstName = "Tauqeer",
               lastName = "Ahmad",
               DateOfBirth = "12-2-3",
               phoneNo = "99268661",
              
               Position = "PS"

           }
           );
            modelBuilder.Entity<Project_Employee>().HasData(
           new Project_Employee
           {
               Id = 1,
               Employee_id = 4,
               project_Id = 2
           },
             new Project_Employee
             {
                 Id = 2,
                 Employee_id = 4,
                 project_Id = 3
             }

              );

        }
        /*
                protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                    {
                        optionsBuilder.UseSqlServer("Server=DESKTOP-UGCEOCR;Database=webApiDb; Trusted_Connection=True;MultipleActiveResultSets=true");
                    }

          /*          protected override void OnModelCreating(ModelBuilder modelBuilder)
                    {
                        modelBuilder.Entity<Employee_Project>().HasKey(sc => new { sc.EmployeesId, sc.ProjectsId });
                    }

                // you added this line
                 //       public DbSet<Employee_Project> EmployeeProjects { get; set; }  */


             /*               ALSO TRY THIS ONE
      *               
      *               modelBuilder.Entity<Employee_Project>().HasKey(sc => new { sc.EId, sc.PId });

     modelBuilder.Entity<Employee_Project>()
         .HasOne<Employees>(sc => sc.Employees)
         .WithMany(s => s.Employee_Project)
         .HasForeignKey(sc => sc.EId);


     modelBuilder.Entity<Employee_Project>()
         .HasOne<Projects>(sc => sc.Projects)
         .WithMany(s => s.Employee_Project)
         .HasForeignKey(sc => sc.PId);
      *               
      *               
      *               
      */
    }
}
