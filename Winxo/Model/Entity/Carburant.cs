﻿using System;
using System.ComponentModel.DataAnnotations;


namespace Winxo.Model.Entity
{
    internal class Carburant
    {
        [Key]
        public Guid CarburantGuid { get; set; }


        public string Nom { get; set; }


        public string TypeCarburant { get; set; }


        public double Seuil { get; set; }




    }
}
