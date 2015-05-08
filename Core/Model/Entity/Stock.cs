using System;
using System.ComponentModel.DataAnnotations;
using Winxo.Model.Enums;


namespace Winxo.Model.Entity
{
    internal class Stock
    {
        [Key]
        public Guid StockGuid { get; set; }

        public StockType StockType { get; set; }


        public double Quantite { get; set; }




        public Fournisseur Fournisseur { get; set; }
    }
}
