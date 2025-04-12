using System.ComponentModel.DataAnnotations;

namespace IntraNet.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }
        [Required]
        public string Password { get; set; }
        public List<EmployeeTask>? TasksAssigned { get; set; }
        public List<Event>? Events { get; set; }

        public int? RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
