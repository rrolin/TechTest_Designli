namespace TechTest.ClientSide.Models
{
    public class EmployeeViewModel
    {
        public string? FullName => $"{FirstName} {LastName}";
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public DateTime? EnteredDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Error { get; set; }
    }
}