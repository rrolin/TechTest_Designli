using TechTest.ClientSide.Models;
using TechTest.ClientSide.Mapping;
using TechTest.Core.Application.DTO;

namespace TechTest.ClientSide.Data
{
    /// <summary>
    /// Service for Employee object operations.
    /// </summary>
    public class EmployeeService : BaseService
    {
        public EmployeeService(IHttpClientFactory factory, AuthenticationState authState)
        : base(factory, authState) { }

        /// <summary>
        /// Get method for retrieve all employees.
        /// </summary>
        /// <returns>Employee list</returns>
        public async Task<List<EmployeeViewModel>> GetEmployeesAsync()
        {
            var employeeDtos = await GetAsync<List<EmployeeDto>>("/api/Employee") ?? new List<EmployeeDto>();

            return employeeDtos.ToViewModel();
        }
    }
}