using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP4.Data;
using TP4.Models;
using TP4.Models.ViewModels;

namespace TP4.Controllers
{
    public class StatsController : Controller
    {
        private readonly TP4Context _context;
        //obligatoire creation instance pour recupérer les données de la base de données 
        public StatsController(TP4Context context)
        {
            _context = context;
        }
        
        public IActionResult ListeEtd()
        {
            var res = from m in _context.Matiére
                      join i in _context.Inscription
                      on m.Id equals i.MatiereId
                      join e in _context.Etudiant
                      on i.EtudiantId equals e.Id
                      select new EtudiantMatiere { Nom=e.Nom,Prenom=e.Prenom, Matiere=m.LibMatiere };
            return View(res);
        }

        public IActionResult EtdNombreM() {
            var res= from i in _context.Inscription 
                     join e in _context.Etudiant
                     on i.EtudiantId equals e.Id
                     group e by e.Id into gr
                     select new NbrMat {
                     Nbr = gr.Count(),
                     Nom=gr.Select(x=>x.Nom).FirstOrDefault(),
                     Prenom = gr.Select(x => x.Nom).FirstOrDefault(),
                     }; 
            return View(res);
        }
    }
}
