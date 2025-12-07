namespace TechTest.ClientSide.Models
{
    public class EmployeeViewModel
    {
        public string? FullName => $"{FirstName} {LastName}";
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Birthdate { get; set; }
        public string? EnteredDate { get; set; }
        public string? UpdatedDate { get; set; }
        public string? Error { get; set; }
    }
}