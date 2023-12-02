using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TP4.Models;
using TP4.Models.ViewModels;

namespace TP4.Data
{
    public class TP4Context : DbContext
    {
        public TP4Context (DbContextOptions<TP4Context> options)
            : base(options)
        {
        }

        public DbSet<TP4.Models.Groupe> Groupe { get; set; } = default!;
        public DbSet<TP4.Models.Etudiant> Etudiant { get; set; } = default!;
        public DbSet<TP4.Models.Inscription> Inscription { get; set; } = default!;
        public DbSet<TP4.Models.Matiere> Matiére { get; set; } = default!;
        public DbSet<TP4.Models.ViewModels.NbrMat>? NbrMat { get; set; }
        //Supprimé : creation auto  public DbSet<TP4.Models.ViewModels.EtudiantMatiere>? EtudiantMatiere { get; set; }
        
    }
}
