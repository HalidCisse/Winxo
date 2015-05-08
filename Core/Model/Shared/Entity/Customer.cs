using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLib.Database;
using Core.Model.Shared.Enums;

namespace Core.Model.Shared.Entity
{

    /// <summary>
    /// un client
    /// </summary>
    public class Customer : Tracable
    {
        [Key]
        public Guid CustomerGuid { get; set; }

        /// <summary>
        /// Guid de la personne Associer
        /// </summary>
        public Guid PersonGuid { get; set; }

        /// <summary>
        /// StaffId
        /// </summary>
        public string Matricule { get; set; }       

        /// <summary>
        /// Experience du Staff
        /// </summary>
        public int Since { get; set; }

        

        /// <summary>
        /// Suspendu, Regulier, Licencier
        /// </summary>
        public StaffStatus Statut { get; set; }




        /// <summary>
        /// La personne Associer
        /// </summary>
        [ForeignKey("PersonGuid")]
        public virtual Person Person { get; set; }


    }
}
