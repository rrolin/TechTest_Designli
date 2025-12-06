using TechTest.Core.Domain.Entities;
using TechTest.Core.Domain.Interfaces;

namespace TechTest.Core.Application.UseCases
{
    public class UpdateEmployeeHandler
    {
        private readonly IEmployeeRepository _repository;

        public UpdateEmployeeHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public void Handle(Employee employee)
        {
            _repository.Update(employee);
        }
    }
}