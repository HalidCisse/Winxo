using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Model.Stocks.Entity
{
    internal class Prelevement 
    {
        [Key]
        public Guid PrelevementGuid { get; set; }



        public Pompe Pompe { get; set; }

        public Journal Journal { get; set; }



    }
}
