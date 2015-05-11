using System.Data.Entity;
using Core.Model.Fuel.Entity;
using Core.Model.Hr.Entity;
using Core.Model.Oil.Entity;
using Core.Model.Sale.Entity;

namespace Core.Model
{
    internal class WinxoContext : DbContext
    {
      
        public WinxoContext() : base("name=conString")
        {

            //          Update-Database 
        }




        #region SHARED

        /// <summary>
        /// Les Clients
        /// </summary>
        public virtual DbSet<Customer.Entity.Customer> Customers { get; set; }

        /// <summary>
        /// Les Personnels
        /// </summary>
        public virtual DbSet<Staff> Staffs { get; set; }

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


        #endregion




        #region ECONOMAT

        /// <summary>
        /// Employements des Staffs
        /// </summary>
        public virtual DbSet<Employment> Employments { get; set; }

        /// <summary>
        /// Renumerations des Employers
        /// </summary>
        public virtual DbSet<Salary> Salaries { get; set; }

        /// <summary>
		/// Methode des Payements des salaires des Staffs et des Enseignants
		/// </summary>		
        public virtual DbSet<Payroll> Payrolls { get; set; }
       

        /// <summary>
        /// Transactions Caisse
        /// </summary>
        public virtual DbSet<Transaction> Transactions { get; set; }


        #endregion


    }
}
