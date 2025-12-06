using TechTest.Core.Domain.Entities;
using TechTest.Core.Domain.Interfaces;

namespace TechTest.Core.Application.UseCases
{
    public class AddEmployeeHandler
    {
        private readonly IEmployeeRepository _repository;

        public AddEmployeeHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public void Handle(Employee employee)
        {
            _repository.Add(employee);
        }
    }
}