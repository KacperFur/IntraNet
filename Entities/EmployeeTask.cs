using System.ComponentModel.DataAnnotations;

namespace IntraNet.Entities
{
    public class EmployeeTask
    {
        public int Id { get; set; }
        public string Tag { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public virtual int? AssignedEmployeeId { get; set; }
        public virtual Employee? AssignedEmployee { get; set; }
    }
}
