using Microsoft.EntityFrameworkCore;
using webApi.DBContexts;
using webApi.Models;


namespace webApi.Repository
{

        public class ProjectRepository : IProjectRepository
        {
            private readonly ProjectContext _dbContext;

            public ProjectRepository(ProjectContext dbContext)
            {
                _dbContext = dbContext;
            }

        public void DeleteProject(int? id)
            {
                var project = _dbContext.Projects.Find(id);
            if (project != null)
                _dbContext.Projects.Remove(project);
                Save();
        }
            public Projects GetProjectsByID(int? id)
            {
                return _dbContext.Projects.Find(id);
            }
            public IEnumerable<Projects> GetProjects()
            {
                return _dbContext.Projects.ToList();
            }

            public void InsertProject(Projects project)
            {
                _dbContext.Add(project);

                Save();
            }
            public void Save()
            {
                _dbContext.SaveChanges();
            }

            public void UpdateProject(Projects project)
            {
                _dbContext.Entry(project).State = EntityState.Modified;
                Save();
            }
        }
}
