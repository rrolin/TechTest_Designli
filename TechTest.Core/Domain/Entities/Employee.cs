namespace TechTest.Core.Domain.Entities
{
    // Employee object per requirement
    public class Employee
    {
        public Employee(int employeeId, string firstName, string lastName, DateTime birthDate, bool isActive, DateTime enteredDate, DateTime updatedDate) 
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthDate;
            IsActive = isActive;
            EnteredDate = enteredDate;
            UpdatedDate = updatedDate;
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        
        // I know it would be best to use a status Id as well, but didn't include anything requiring more complexity in order to keep the test simple.
        public bool IsActive { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}