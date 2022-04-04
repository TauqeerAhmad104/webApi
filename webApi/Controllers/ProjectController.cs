using Microsoft.AspNetCore.Mvc;
using webApi.Models;
using webApi.Repository;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webApi.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class ProjectController : ControllerBase
        {
            private readonly IProjectRepository _ProjectRepository;

            public ProjectController(IProjectRepository ProjectRepository)
            {
                _ProjectRepository = ProjectRepository;
            }

            [HttpGet]
            public IActionResult Get()
            {
                var Projects = _ProjectRepository.GetProjects();
                return new OkObjectResult(Projects);
            }
            [HttpGet("{id}", Name = "GetProject")]
            public IActionResult Get(int id)
            {
                var Project = _ProjectRepository.GetProjectsByID(id);
                return new OkObjectResult(Project);
            }

            [HttpPost]
            public IActionResult Post([FromBody] Projects Project)
            {
                using (var scope = new TransactionScope())
                {
                    _ProjectRepository.InsertProject(Project);
                    scope.Complete();
                    return CreatedAtAction(nameof(Get), new { id = Project.Id }, Project);
                }
            }

            [HttpPut]
            public IActionResult Put([FromBody] Projects Project)
            {
                if (Project != null)
                {
                    using (var scope = new TransactionScope())
                    {
                        _ProjectRepository.UpdateProject(Project);
                        scope.Complete();
                        return new OkResult();
                    }
                }
                return new NoContentResult();
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                _ProjectRepository.DeleteProject(id);
                return new OkResult();
            }
        }
    }
