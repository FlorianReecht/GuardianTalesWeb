using System.ComponentModel.DataAnnotations.Schema;

namespace GuardianTalesWeb.Models
{
    public class Team
    {
        public int Type_Team_Num { get; set; }

        public int Joueur_Num { get; set; } 

        public int Team_Degats { get; set; }
        
        [ForeignKey("Type_Team_Num")]
        public Team_Type Team_Type { get; set; }
        
        [ForeignKey("Joueur_Num")]
        public Joueur Joueur { get; set; }
    }
}
