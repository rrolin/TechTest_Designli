using TechTest.Core.Domain.Entities;
using TechTest.Infrastructure.Persistence;

namespace TechTest.Test.Repositories
{
    public class InMemoryEmployeeRepositoryTests
    {
        [Fact]
        public void GetAllEmployeesTest()
        {
            var repository = new InMemoryEmployeeRepository();
            var employees = repository.GetAll();

            Assert.NotEmpty(employees);
        }

        [Fact]
        public void AddEmployeeTest()
        {
            var repository = new InMemoryEmployeeRepository();
            var newEmployee = new Employee
                (
                    employeeId: 5,
                    firstName: "Chuck",
                    lastName: "Norris",
                    birthDate: DateTime.Now,
                    isActive: true,
                    enteredDate: DateTime.Now,
                    updatedDate: DateTime.Now
                );

            repository.Add(newEmployee);
            Assert.Contains(repository.GetAll(), e => e.FirstName == "Chuck" && e.LastName == "Norris");
        }

        [Fact]
        public void UpdateEmployeeTest()
        {
            var repository = new InMemoryEmployeeRepository();
            var updatingEmployee = new Employee
            (
                employeeId: 2,
                firstName: "Emmet",
                lastName: "Brown",
                birthDate: new DateTime(1938, 10, 22),
                isActive: true,
                enteredDate: new DateTime(1985, 11, 5),
                updatedDate: new DateTime(1985, 11, 5)
            );

            repository.Update(updatingEmployee);

            var updatedEmployee = repository.GetById(2);

            Assert.NotNull(updatedEmployee);
            Assert.Equal(1985, updatedEmployee.UpdatedDate.Year);
        }

        [Fact]
        public void DeleteEmployeeTest()
        {
            var repository = new InMemoryEmployeeRepository();
            var employeeCountBefore = repository.GetAll().Count();
            repository.Delete(employeeId: 1);
            var employeeCountAfter = repository.GetAll().Count();

            Assert.NotEqual(employeeCountBefore, employeeCountAfter);
        }
    }
}