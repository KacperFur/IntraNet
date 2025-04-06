using System.ComponentModel.DataAnnotations;

namespace IntraNet.Models
{
    public class EmployeeTaskDto
    {
        public int Id { get; set; }
        public string Tag { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        //[Required]
        public virtual int AuthorId { get; set; }
        public virtual int? AssignedEmployeeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
