using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace Winxo.Model.Entity
{
    internal class Journal
    {
        [Key]
        public Guid JournalGuid { get; set; }





        public List<Prelevement> Prelevements { get; set; }

    }
}
