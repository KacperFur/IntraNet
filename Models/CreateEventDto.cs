using System.ComponentModel.DataAnnotations;

namespace IntraNet.Models
{
    public class CreateEventDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public int AuthorId { get; set; }
    }
}
