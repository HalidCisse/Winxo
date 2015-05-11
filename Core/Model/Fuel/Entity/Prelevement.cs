using System;
using System.ComponentModel.DataAnnotations;
using Core.Model.Sale.Entity;

namespace Core.Model.Fuel.Entity
{
    internal class Prelevement 
    {
        [Key]
        public Guid PrelevementGuid { get; set; }



        public Pompe Pompe { get; set; }

        public Journal Journal { get; set; }



    }
}
