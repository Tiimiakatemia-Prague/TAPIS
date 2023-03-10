using CzuEseje.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace CzuEseje.Models
{
    public class Esej
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Název eseje je povinný")]
        public string Title { get; set; }
        public DateTime DateC { get; set; } 
        public string Text { get; set; }
        public string TextRaw { get; set; }
        public ApplicationUser User { get; set; }
        public Source? Source { get; set; }
    }
}
