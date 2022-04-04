using Microsoft.AspNetCore.Mvc;
using webApi.Models;
using webApi.Repository;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectEmployeeController : ControllerBase
    {

        private readonly IProjectEmployeeRepository _ProjectEmployeeRepository;

        public ProjectEmployeeController(IProjectEmployeeRepository ProjectRepository)
        {
            _ProjectEmployeeRepository = ProjectRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var projectEmployees = _ProjectEmployeeRepository.GetProjectEmployees();
            return new OkObjectResult(projectEmployees);
        }


        [HttpGet("Available/{id}", Name = "GetAvailableEmployees")]
        public IActionResult GetAvailable(int id)
        {
            var employees = _ProjectEmployeeRepository.GetAvailableEmployees(id);
            return new OkObjectResult(employees);
        }
        [HttpGet("Assigned/{id}", Name = "GetAssignedEmployees")]
        public IActionResult GetAssigned(int id)
        {
            var employees = _ProjectEmployeeRepository.GetAssingnedEmployees(id);
            return new OkObjectResult(employees);
        }
        [HttpGet("delete/{idProject}/{idEmployee}", Name = "delete")]
        public IActionResult GetAssigned(int idProject, int idEmployee)
        {
            _ProjectEmployeeRepository.DeleteProjectEmployee(idProject,idEmployee);
            return new OkResult();

        }
        [HttpPost]
        public IActionResult Post([FromBody] ProjectEmployeeViewModel Project)
        {

            var result = _ProjectEmployeeRepository.InsertProjectEmployee(Project);

            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);

        }


        [HttpPut]
        public IActionResult Put([FromBody] Project_Employee Project)
        {
            if (Project != null)
            {
                using (var scope = new TransactionScope())
                {
                    _ProjectEmployeeRepository.UpdateProjectEmployee(Project);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _ProjectEmployeeRepository.DeleteProjectEmployee(id);
            return new OkResult();
        }

    }
}
