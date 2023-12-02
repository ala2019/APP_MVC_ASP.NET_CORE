using System.ComponentModel.DataAnnotations;

namespace TP4.Models.ViewModels
{
    public class EtudiantMatiere
    {
        public int Id { get; set; }
  
        public string Nom { get; set; }
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }
        [Display(Name = "Matiére")]
        public string Matiere { get; set; }
    }
}
