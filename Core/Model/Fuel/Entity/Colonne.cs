using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Model.Fuel.Entity
{
    internal class Colonne
    {
        [Key]
        public Guid ColonneGuid { get; set; }

        public string Nom { get; set; }



        public List<Pompe> Pompes { get; set; }


    }
}
