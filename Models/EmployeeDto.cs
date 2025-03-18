using System.ComponentModel.DataAnnotations;
using IntraNet.Entities;

namespace IntraNet.Models
{
    public class EmployeeDto
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
        public virtual List<EmployeeTaskDto> TasksAssigned { get; set; }
        public virtual List<EventDto> Events { get; set; }
    }
}
