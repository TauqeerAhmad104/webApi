using webApi.Models;
using System.Collections.Generic;

namespace webApi.Repository
{
    public interface IProjectRepository
    {
        IEnumerable<Projects> GetProjects();
        Projects GetProjectsByID(int? id);
        void InsertProject(Projects project);
        void UpdateProject(Projects project);
        void DeleteProject(int? id);
        void Save();
    }
}
