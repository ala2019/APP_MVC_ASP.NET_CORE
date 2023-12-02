using System.ComponentModel.DataAnnotations;

namespace TP4.Models
{
    public class Matiere
    {
        public int Id { get; set; }
        [Display(Name = "Matière")]
        [Required, StringLength(30, MinimumLength = 3)]
        public string LibMatiere { get; set; }
        public virtual ICollection<Inscription>? Inscriptions { get; set; }
    }
}
