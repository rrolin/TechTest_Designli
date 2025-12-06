using Microsoft.AspNetCore.Mvc;
using TechTest.Core.Domain.Entities;
using TechTest.Core.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize] // Require JWT, for testing purpose this one will be the one and only endpoint that requires authentication.
        public IActionResult GetEmployees()
        {
            var employees = _repository.GetAll();
            return Ok(employees);
        }

        [HttpGet]
        [AllowAnonymous] // For easy swagger testing, not meant to work like that IRL.
        public IActionResult GetEmployeeById(int employeeId)
        {
            var employees = _repository.GetById(employeeId);
            return Ok(employees);
        }

        [HttpPost]
        [AllowAnonymous] // For easy swagger testing, not meant to work like that IRL.
        public IActionResult Add(Employee employee)
        {
            _repository.Add(employee);
            return Ok();
        }

        [HttpPut]
        [AllowAnonymous] // For easy swagger testing, not meant to work like that IRL.
        public IActionResult Update(Employee employee)
        {
            if (employee.EmployeeId < 1) return BadRequest();

            _repository.Update(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [AllowAnonymous] // For easy swagger testing, not meant to work like that IRL.
        public IActionResult Delete(int employeeId)
        {
            _repository.Delete(employeeId);
            return NoContent();
        }
    }
}