using System;
using System.ComponentModel.DataAnnotations;
using Core.Model.Shared.Enums;

namespace Core.Model.Oil.Entity
{
    internal class Huile
    {

        [Key]
        public Guid HuileGuid { get; set; }


        public TypeHuile TypeHuile { get; set; }



        public double Seuil { get; set; }



    }
}
