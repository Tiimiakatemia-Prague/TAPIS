using System.ComponentModel.DataAnnotations;

namespace CzuEseje.Models
{
    public class TypeOfSource
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
