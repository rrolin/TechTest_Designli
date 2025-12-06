using TechTest.Core.Domain.Entities;
using TechTest.Core.Domain.Interfaces;

namespace TechTest.Infrastructure.Persistence
{
    public class InMemoryEmployeeRepository : IEmployeeRepository
    {
        // In memory data
        private readonly List<Employee> _employees = new()
        {
            new Employee(
                employeeId: 1, 
                firstName: "Gandalf", 
                lastName: "The Grey", 
                birthDate: new DateTime(1939, 5, 25),
                isActive: true, 
                enteredDate: new DateTime(2001, 12, 19),
                updatedDate: new DateTime(2001, 12, 19)
            ),
            new Employee(
                employeeId: 2,
                firstName: "Emmet",
                lastName: "Browm",
                birthDate: new DateTime(1938, 10, 22),
                isActive: true,
                enteredDate: new DateTime(1955, 11, 5),
                updatedDate: new DateTime(1955, 11, 5)
            ),
            new Employee(
                employeeId: 3,
                firstName: "Egon",
                lastName: "Spengler",
                birthDate: new DateTime(1944, 11, 21),
                isActive: true,
                enteredDate: new DateTime(1984, 6, 8),
                updatedDate: new DateTime(1984, 6, 8)
            ),
            new Employee(
                employeeId: 4,
                firstName: "QuiGon",
                lastName: "Jinn",
                birthDate: new DateTime(1952, 6, 7),
                isActive: true,
                enteredDate: new DateTime(1999, 5, 19),
                updatedDate: new DateTime(1999, 5, 19)
            ),
        };

        /// <summary>
        /// Get method for all employee objects in list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetAll() => _employees.Where(employee => employee.IsActive);

        /// <summary>
        /// Get method for employee object
        /// </summary>
        /// <param name="employeeId">Employee Id to look</param>
        /// <returns>Employee</returns>
        public Employee? GetById(int employeeId) =>
            _employees
            .FirstOrDefault
            (
                employee => 
                employee.EmployeeId == employeeId
                && employee.IsActive
            );

        /// <summary>
        /// Add method for employee object
        /// </summary>
        /// <param name="employee"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void Add(Employee employee)
        {
            // Make sure it does not exists
            if (_employees.Any(e => e.EmployeeId == employee.EmployeeId))
                throw new InvalidOperationException("Employee with same Id already exists.");

            _employees.Add(employee);
        }

        /// <summary>
        /// Update method for employee object
        /// </summary>
        /// <param name="employee"></param>
        /// <exception cref="KeyNotFoundException"></exception>
        public void Update(Employee employee)
        {
            var existingEmployee = GetById(employee.EmployeeId);

            if (existingEmployee == null)
                throw new KeyNotFoundException("Employee not found.");

            // Replace values, not the fancier way but it works better for list
            _employees.Remove(existingEmployee);
            _employees.Add(employee);
        }

        /// <summary>
        /// Delete method for employee object
        /// </summary>
        /// <param name="employeeId">EmployeeId to remove</param>
        public void Delete(int employeeId)
        {
            var employeeToRemove = _employees
                .FirstOrDefault
                (
                    employee => 
                    employee.EmployeeId == employeeId
                    && employee.IsActive
                );
            
            // We don't hard delete here
            if (employeeToRemove is not null)
            {
                employeeToRemove.IsActive = false;
                employeeToRemove.UpdatedDate = DateTime.Now;
                Update(employeeToRemove);
            }
        }
    }
}