using System.ComponentModel.DataAnnotations;

namespace IntraNet.Models
{
    public class CreateEmployeeDto
    {
        //[Required]
        public string FirstName { get; set; }
        //[Required]
        public string LastName { get; set; }
        //[Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }
        //[Required]
        public string Password { get; set; }
        public int? RoleId { get; set; }
    }
}
