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
        public DbSet<Team_Type> Team_Type { get; set; }
        public DbSet<Team> Team { get; set; }
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
            //Primary Keys
            model.Entity<Guilde>().HasKey(g => g.Guilde_Num).HasName("GUILD_NUM");
            model.Entity<Team_Type>().HasKey(tt => tt.Type_Team_Num).HasName("Type_Team_Num");
            model.Entity<Joueur>().HasKey(j => j.Joueur_Num).HasName("JOUEUR_NUM");
            model.Entity<Team>().HasKey(t => t.Type_Team_Num).HasName("Type_Team_Num");
            model.Entity<Team>().HasKey(t => t.Joueur_Num).HasName("Joueur_Num");
          
            //Association 1n entre joueur et guilde
            model.Entity<Joueur>().HasOne( j => j.Guilde).WithMany(g => g.Joueurs).HasForeignKey(j=> j.Guilde_Num).IsRequired();

          

            //Clé composée
            model.Entity<Team>()
           .HasKey(t => new { t.Type_Team_Num, t.Joueur_Num });

        }

        public List<Joueur> GetAllJoueur()//Retourne tous les joueurs
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
        public Joueur GetOneJoueur(int id)//Retourne le joueur d'id ID
        {
            using (var db = new GuardianTalesContext())
            {
                var joueur = db.Joueur.Where(j=>j.Joueur_Num == id).Include(joueur => joueur.Teams).ThenInclude(t => t.Team_Type).FirstOrDefault();
                if (joueur == null)
                {
                    throw new System.Exception();
                }
                else
                {
                    return joueur;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id" id de la guilde></param>
        /// <returns>Liste des joueurs de la guilde</returns>
        public List<Joueur> GetJoueurFromGuild(int id)
        {
            using(var db = new GuardianTalesContext())
            {
                var joueurs = db.Joueur.Where(j => j.Guilde_Num == id).Include(j =>j.Guilde).Include(joueur => joueur.Teams).ThenInclude(t => t.Team_Type).ToList();
                return joueurs;
            }
        }
    }
}