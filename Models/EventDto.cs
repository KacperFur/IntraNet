using System.ComponentModel.DataAnnotations;

namespace IntraNet.Models
{
    public class EventDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public int AuthorId { get; set; }
    }
}
