using System.ComponentModel.DataAnnotations;

namespace IntraNet.Models
{
    public class UpdateEmployeeDto
    {
        [Required]
        public string Email { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }
    }
}
