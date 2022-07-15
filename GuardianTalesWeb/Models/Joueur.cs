using System.ComponentModel.DataAnnotations.Schema;

namespace GuardianTalesWeb.Models
{
    public class Joueur
    {
        
        public int Joueur_Num { get; set; }
        public string Joueur_Nom { get; set;}
        public int GuildNum { get; set; }

        [ForeignKey("GuildNum")]//Underscore peut être?
        public Guilde JoueurGuilde { get; set; }
    }
}
