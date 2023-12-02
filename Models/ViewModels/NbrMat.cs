using System.ComponentModel.DataAnnotations;

namespace TP4.Models.ViewModels
{
    public class NbrMat
    {
        public int Id { get; set; }

        public string Nom { get; set; }
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }
        [Display(Name = "Nombre Matiére")]
        public int Nbr { get; set; }
    }
}
