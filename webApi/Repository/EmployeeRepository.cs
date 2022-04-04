using Microsoft.EntityFrameworkCore;
using webApi.DBContexts;
using webApi.Models;

namespace webApi.Repository
{

        public class EmployeeRepository : IEmployeeRepository
        {
        private readonly ProjectContext _dbContext;

        public EmployeeRepository(ProjectContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteEmployees(int id)
        {
            var employee = _dbContext.Employees.Find(id);
            _dbContext.Employees.Remove(employee);
            Save();
        }
        public Employees GetEmployeesByID(int id)
        {
            return _dbContext.Employees.Find(id);
        }
        public IEnumerable<Employees> GetEmployees()
        {
            return _dbContext.Employees.ToList();
        }
        public void InsertEmployees(Employees employee)
        {
            _dbContext.Add(employee);
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public void UpdateEmployees(Employees employee)
        {
            _dbContext.Entry(employee).State = EntityState.Modified;
            Save();
        }

    }
}
