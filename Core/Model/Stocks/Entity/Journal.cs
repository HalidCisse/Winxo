using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Model.Stocks.Entity
{
    internal class Journal
    {
        [Key]
        public Guid JournalGuid { get; set; }





        public List<Prelevement> Prelevements { get; set; }

    }
}
