using System.Data.Entity;
using Winxo.Model.Entity;

namespace Winxo.Model
{
    internal class WinxoContext : DbContext
    {
      
        public WinxoContext() : base("name=conString")
        {
        }

        //          Update-Database 
        //          Update-Database 




        /// <summary>
        /// Les Personnels
        /// </summary>
        public virtual DbSet<Personnel> Personnels { get; set; }

        /// <summary>
        /// Les Pomps
        /// </summary>
        public virtual DbSet<Pompe> Pompes { get; set; }

        /// <summary>
        /// Les Colonne
        /// </summary>
        public virtual DbSet<Colonne> Colonnes { get; set; }

        /// <summary>
        /// Les Citernes
        /// </summary>
        public virtual DbSet<Citerne> Citernes { get; set; }


        /// <summary>
        /// Les Huile
        /// </summary>
        public virtual DbSet<Huile> Huiles { get; set; }



    }
}
