using System;
using System.ComponentModel.DataAnnotations;
using Winxo.Model.Enums;

namespace Winxo.Model.Entity
{
    internal class Huile
    {

        [Key]
        public Guid HuileGuid { get; set; }


        public TypeHuile TypeHuile { get; set; }







    }
}
