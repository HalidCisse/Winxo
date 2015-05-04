using System.Data.Entity;
using Winxo.Entity.Shared.Entity;

namespace Winxo.Entity
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





    }
}
