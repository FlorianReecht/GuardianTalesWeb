using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;

namespace GuardianTalesWeb.Models
{
    public class GuardianTalesContext :DbContext
    {
        public DbSet<Joueur> Joueur { get; set; }
        public DbSet<Guilde> Guilde { get; set; }
        public string ConnectionString { get; set; }

        public GuardianTalesContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public GuardianTalesContext()
        {
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder )
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=;database=guardiantales");

            }
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Guilde>().HasKey(g => g.Guilde_Num).HasName("GUILD_NUM");
            model.Entity<Joueur>().HasKey(j =>j.Joueur_Num).HasName("JOUEUR_NUM");
            model.Entity<Joueur>().HasOne( j => j.Guilde).WithMany(g => g.Joueurs).HasForeignKey(j=> j.Guilde_Num).IsRequired();
        }

        public List<Joueur> GetAllJoueur()
        {

            List<Joueur> retour = new List<Joueur>();
            using (var db = new GuardianTalesContext())
            {
                var joueurs = db.Joueur.Include(j => j.Guilde).ToList();
                foreach (Joueur joueur in joueurs)
                {
                    retour.Add(joueur);
                }

            }
            return retour;
        }

        //public List<Joueur> GetAllJoueur()
        //{
        //    List<Joueur> retour = new List<Joueur>();
        //    using(MySqlConnection conn = GetConnection())
        //    {
        //        conn.Open();
        //        MySqlCommand cmd = new MySqlCommand("select * from joueur",conn);
        //        using(var reader = cmd.ExecuteReader())
        //        {
        //            while(reader.Read())
        //            {
        //                retour.Add(new Joueur()
        //                {
        //                    Joueur_Num = Convert.ToInt32(reader["JOUEUR_NUM"]),
        //                    Joueur_Name = reader["JOUEUR_NOM"].ToString(),
        //                    Joueur_Guild = Convert.ToInt32(reader["JOUEUR_GUILD"])
        //                });


        //            }
        //        }
        //    }
        //    return retour;
        //}
    }
}