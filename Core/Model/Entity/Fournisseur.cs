using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winxo.Model.Entity
{
    internal class Fournisseur
    {
        [Key]
        public Guid FournisseurGuid { get; set; }

        public string Nom { get; set; }


        public string Tel { get; set; }


        public string Fax { get; set; }


        public string Adresse { get; set; }





    }
}
