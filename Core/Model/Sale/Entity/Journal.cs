using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Model.Fuel.Entity;

namespace Core.Model.Sale.Entity
{
    internal class Journal
    {
        [Key]
        public Guid JournalGuid { get; set; }





        public List<Prelevement> Prelevements { get; set; }

    }
}
