using System.ComponentModel.DataAnnotations;

namespace IntraNet.Models
{
    public class CreateEmployeeTaskDto
    {
        public string Tag { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int AssignedEmployeeId { get; set; }
    }
}
