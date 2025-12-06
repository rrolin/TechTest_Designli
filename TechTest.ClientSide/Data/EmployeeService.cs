using TechTest.ClientSide.Models;
using TechTest.Core.Application.DTO;

namespace TechTest.ClientSide.Data
{
    public class EmployeeService : BaseService
    {
        public EmployeeService(IHttpClientFactory factory, AuthenticationState authState)
        : base(factory, authState) { }
        public async Task<List<EmployeeViewModel>> GetEmployeesAsync()
        {
            var dtos = await GetAsync<List<EmployeeDto>>("/api/employees") ?? new List<EmployeeDto>();

            return dtos.Select(dto => new EmployeeViewModel
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Birthdate = dto.Birthdate,
                EnteredDate = dto.EnteredDate,
                UpdatedDate = dto.UpdatedDate,
                Error = dto.Errors.FirstOrDefault()
            }).ToList();
        }
    }
}