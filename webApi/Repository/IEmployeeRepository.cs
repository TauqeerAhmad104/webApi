using webApi.Models;
namespace webApi.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employees> GetEmployees();
        Employees GetEmployeesByID(int id);
        void InsertEmployees(Employees employee);
        void UpdateEmployees(Employees employee);
        void DeleteEmployees(int id);
        void Save();
    }
}
