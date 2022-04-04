
using webApi.Models;
using System.Collections.Generic;
namespace webApi.Repository
{
    public interface IProjectEmployeeRepository
    {
        IEnumerable<Employees> GetAssingnedEmployees(int idProject);
        public IEnumerable<Employees> GetAvailableEmployees(int idProject);
        Project_Employee InsertProjectEmployee(ProjectEmployeeViewModel empproj);
        void UpdateProjectEmployee(Project_Employee empproj);
        void DeleteProjectEmployee(int id);
        void Save();
        public IEnumerable<Project_Employee> GetProjectEmployees();
        public void DeleteProjectEmployee(int idProject, int idEmployee);
    }
}
