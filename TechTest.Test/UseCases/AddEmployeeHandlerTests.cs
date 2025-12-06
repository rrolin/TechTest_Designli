using TechTest.Core.Domain.Entities;
using TechTest.Core.Application.UseCases;
using TechTest.Infrastructure.Persistence;

namespace TechTest.Test.UseCases
{
    public class AddEmployeeHandlerTests
    {
        [Fact]
        public void HandleAddEmployeeToRepositoryTest()
        {
            var repo = new InMemoryEmployeeRepository();
            var handler = new AddEmployeeHandler(repo);

            var newEmployee = new Employee(4, "Bruce", "Wayne", DateTime.Now, true, DateTime.Now, DateTime.Now);
            handler.Handle(newEmployee);

            var employee = repo.GetById(4);
            Assert.NotNull(employee);
            Assert.Equal("Bruce", employee?.FirstName);
        }
    }
}