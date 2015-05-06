using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Winxo.Model.Entity
{
    internal class Pompe
    {

        [Key]
        public Guid PompeGuid { get; set; }

        public Guid ColonneGuid { get; set; }

        public Guid CiterneGuid { get; set; }

        public int PompeurMecanique { get; set; }

        public double PompeurElectronique1 { get; set; }

        public double PompeurElectronique2 { get; set; }

        public double PompeurElectronique3 { get; set; }



        [ForeignKey("CiterneGuid")]
        public virtual Citerne Citerne { get; set; }

        [ForeignKey("ColonneGuid")]
        public virtual Colonne Colonne { get; set; }
    }
}
