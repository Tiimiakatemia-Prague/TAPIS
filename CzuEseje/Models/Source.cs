using System.ComponentModel.DataAnnotations;

namespace CzuEseje.Models
{
    public class Source
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
