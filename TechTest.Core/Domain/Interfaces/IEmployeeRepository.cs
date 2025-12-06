using TechTest.Core.Domain.Entities;

namespace TechTest.Core.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee? GetById(int id);
        void Add(Employee employee);
        void Update(Employee employeeId);
        void Delete(int id);
    }
}