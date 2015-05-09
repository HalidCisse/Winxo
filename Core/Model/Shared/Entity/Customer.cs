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

       
        public Guid PersonGuid { get; set; }

       
        public string Matricule { get; set; }

        
        public string Service { get; set; }

       
        public int Since { get; set; }

               
        public CustomerStatus CustomerStatus { get; set; }


        
        [ForeignKey("PersonGuid")]
        public virtual Person Person { get; set; }


    }
}
