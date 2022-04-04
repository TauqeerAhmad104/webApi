using Microsoft.EntityFrameworkCore;
using webApi.DBContexts;
using webApi.Models;

namespace webApi.Repository
{
    public class ProjectEmployeeRepository : IProjectEmployeeRepository
    {
        private readonly ProjectContext _dbContext;
        public ProjectEmployeeRepository(ProjectContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Project_Employee> GetProjectEmployees()
        {
            return _dbContext.Projects_Employee.ToList();
        }
        public IEnumerable<Employees> GetAssingnedEmployees(int idProject)
        {
            // select only project that have project_id = id
            var employeeIds = _dbContext.Projects_Employee.Where(employeeIds => employeeIds.project_Id == idProject).Select(u => u.Employee_id).ToList();
            return _dbContext.Employees.Where(employee => employeeIds.Contains(employee.Id));
          

        }
        Boolean contains(IEnumerable<Employees> employees, Employees employee)
        {
            foreach (var emp in employees)
            {
                if (emp.Id == employee.Id)
                {
                    return true;
                }
            }
            return false;
        }
        public IEnumerable<Employees> GetAvailableEmployees(int idProject)
        {
            // select only project that have project_id = id
            List<Employees> empls = new List<Employees>();
            List<Project_Employee> project_Employees = _dbContext.Projects_Employee.ToList();
            IEnumerable<Employees> assigned = GetAssingnedEmployees(idProject);
            IEnumerable<Employees> allEmployees = _dbContext.Employees.ToList();
            foreach (var employee in allEmployees)
            {
                if (!contains(assigned, employee))
                {
                    empls.Add(employee);
                }
            }
            return empls;

        }

        public Project_Employee InsertProjectEmployee(ProjectEmployeeViewModel empproj)
        {
            Project_Employee employees = new Project_Employee();
            employees.project_Id = empproj.project_Id;
            employees.Employee_id = empproj.Employee_id;
            _dbContext.Add(employees);
            _dbContext.SaveChanges();
            return employees;

        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }


        void IProjectEmployeeRepository.UpdateProjectEmployee(Project_Employee empproj)
        {
            _dbContext.Entry(empproj).State = EntityState.Modified;
            Save();
        }
        public void DeleteProjectEmployee(int id)
        {
            var projectEmployee = _dbContext.Projects_Employee.Find(id);
            _dbContext.Projects_Employee.Remove(projectEmployee);
            Save();
        }

        public void DeleteProjectEmployee(int idProject, int idEmployee)
        {
           var projectEmployee = _dbContext.Projects_Employee.Where(x => x.Employee_id == idEmployee && x.project_Id == idProject).First();

            _dbContext.Projects_Employee.Remove(projectEmployee);
            Save();
        }

        /*
                public void DeleteProjectEmployee(int id)
                {
                    var projectEmployee = _dbContext.Projects_Employee.Find(id);
                    _dbContext.Projects_Employee.Remove(projectEmployee);
                    Save();
                }
                public Employees GetEmployeesByID(int id)
                {
                    return _dbContext.Employees.Find(id);
                }

                public void InsertProjectEmployee(Project_Employee emppro)
                {
                    _dbContext.Add(emppro);
                    Save();
                }
                public void Save()
                {
                    _dbContext.SaveChanges();
                }

                void IProjectEmployeeRepository.UpdateProjectEmployee(Project_Employee empproj)
                {
                    _dbContext.Entry(empproj).State = EntityState.Modified;
                    Save();
                }
        */

    }
}
