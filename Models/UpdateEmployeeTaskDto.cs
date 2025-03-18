namespace IntraNet.Models
{
    public class UpdateEmployeeTaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public virtual int AssignedEmployeeId { get; set; }
    }
}
