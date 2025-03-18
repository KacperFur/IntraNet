using System.ComponentModel.DataAnnotations;

namespace IntraNet.Entities
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
