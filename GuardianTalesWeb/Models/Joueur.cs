using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuardianTalesWeb.Models
{
    public class Joueur
    {
        
        public int Joueur_Num { get; set; }
        public string Joueur_Nom { get; set;}
        public int Guilde_Num { get; set; }

       
        public Guilde Guilde { get; set; }
        public ICollection<Team> Teams { get; set; }
    }
}
