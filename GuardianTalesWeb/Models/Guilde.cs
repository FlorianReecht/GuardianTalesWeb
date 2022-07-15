using System.Collections.Generic;

namespace GuardianTalesWeb.Models
{
    public class Guilde
    {
       public int Guilde_Num { get; set; }

       public   string Guilde_Name { get; set; }

       public ICollection<Joueur> Joueurs { get; set; }

    }
}
