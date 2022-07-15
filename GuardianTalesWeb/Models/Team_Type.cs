using System.Collections.Generic;

namespace GuardianTalesWeb.Models
{
    public class Team_Type
    {
        public int Type_Team_Num { get; set; }

        public string Type_Team_Lib { get; set; }

        public ICollection<Team> Teams { get; set; } //Toutes les teams d'un élément

    }
}
