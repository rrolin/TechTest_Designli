using TechTest.ClientSide.Models;
using TechTest.Core.Application.DTO;
using TechTest.Core.Common.Extensions;

namespace TechTest.ClientSide.Mapping
{
    /// <summary>
    /// Extension class mapping to handle EmployeeDto to EmployeeViewModel conversions.
    /// </summary>
    public static class EmployeeMapping
    {
        /// <summary>
        /// Converts a list of EmployeeDto from Core definition to ViewModel definition.
        /// </summary>
        /// <param name="dtos">List of EmployeeDto</param>
        /// <returns>List of EmployeeViewModel from EmployeeDto</returns>
        public static List<EmployeeViewModel> ToViewModel(this List<EmployeeDto> dtos) =>
            dtos.Select(dto => dto.ToViewModel()).ToList();

        /// <summary>
        /// Converts a single EmployeeDto from Core definition to ViewModel definition.
        /// </summary>
        /// <param name="dto">EmployeeDto</param>
        /// <returns>EmployeeViewModel from EmployeeDto</returns>
        public static EmployeeViewModel ToViewModel(this EmployeeDto dto) =>
            new EmployeeViewModel
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Birthdate = dto.Birthdate.ToDisplayDate(),
                EnteredDate = dto.EnteredDate.ToDisplayDate(),
                UpdatedDate = dto.UpdatedDate.ToDisplayDate(),
                Error = dto.Errors.FirstOrDefault()
            };
    }
}