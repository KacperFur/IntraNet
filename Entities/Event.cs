using System.ComponentModel.DataAnnotations;

namespace IntraNet.Entities
{
    public class Event
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int? AuthorId { get; set; }
        public Employee? EventAuthor { get; set; }
    }
}
