using TechTest.ClientSide.Models;
using TechTest.Core.Application.DTO;

namespace TechTest.ClientSide.Mapping
{
    public static class EmployeeMapping
    {
        public static EmployeeViewModel ToViewModel(EmployeeDto dto) =>
            new EmployeeViewModel
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Birthdate = dto.Birthdate,
                EnteredDate = dto.EnteredDate,
                UpdatedDate = dto.UpdatedDate,
                Error = dto.Errors.FirstOrDefault()
            };
    }
}