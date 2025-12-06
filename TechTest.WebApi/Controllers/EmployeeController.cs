using Microsoft.AspNetCore.Mvc;
using TechTest.Core.Domain.Entities;
using TechTest.Core.Domain.Interfaces;

namespace TechTest.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _repository.GetAll();
            return Ok(employees);
        }

        [HttpGet]
        public IActionResult GetEmployeeById(int employeeId)
        {
            var employees = _repository.GetById(employeeId);
            return Ok(employees);
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            _repository.Add(employee);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Employee employee)
        {
            if (employee.EmployeeId < 1) return BadRequest();

            _repository.Update(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int employeeId)
        {
            _repository.Delete(employeeId);
            return NoContent();
        }
    }
}