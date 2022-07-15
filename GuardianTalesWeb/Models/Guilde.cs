using System.Collections.Generic;

namespace GuardianTalesWeb.Models
{
    public class Guilde
    {
       public int GuildNum { get; set; }

       public   int Guild_Name { get; set; }

       public ICollection<Joueur> Joueurs { get; set; }

    }
}
