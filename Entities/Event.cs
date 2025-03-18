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
        [Required]
        public int AuthorId { get; set; }
        public virtual Employee EventAuthor { get; set; }
    }
}
