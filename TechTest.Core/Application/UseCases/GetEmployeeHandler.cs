using TechTest.Core.Application.DTO;
using TechTest.Core.Domain.Interfaces;

namespace TechTest.Core.Application.UseCases
{
    public class GetEmployeeHandler
    {
        private readonly IEmployeeRepository _repository;

        public GetEmployeeHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<EmployeeDto> Handle()
        {
            return _repository.GetAll()
                .Select(e => new EmployeeDto
                {
                    EmployeeId = e.EmployeeId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Birthdate = e.Birthdate,
                    EnteredDate = e.EnteredDate,
                    UpdatedDate = e.UpdatedDate,
                    //Errors = e.err
                });
        }
    }
}