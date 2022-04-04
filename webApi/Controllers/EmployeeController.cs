using Microsoft.AspNetCore.Mvc;
using webApi.Models;
using webApi.Repository;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _EmployeeRepository;

        public EmployeeController(IEmployeeRepository EmployeeRepository)
        {
            _EmployeeRepository = EmployeeRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var Employees = _EmployeeRepository.GetEmployees();
            return new OkObjectResult(Employees);
        }
        [HttpGet("{id}", Name = "GetEmployee")]
        public IActionResult Get(int id)
        {
            var Employee = _EmployeeRepository.GetEmployeesByID(id);
            return new OkObjectResult(Employee);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employees Employee)
        {
            using (var scope = new TransactionScope())
            {
                _EmployeeRepository.InsertEmployees(Employee);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = Employee.Id }, Employee);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Employees Employee)
        {
            if (Employee != null)
            {
                using (var scope = new TransactionScope())
                {
                    _EmployeeRepository.UpdateEmployees(Employee);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _EmployeeRepository.DeleteEmployees(id);
            return new OkResult();
        }
    }
}
