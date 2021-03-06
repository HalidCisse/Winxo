﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Model.Sale.Entity
{
    public class Purchase
    {
        [Key]
        public Guid AchatGuid { get; set; }


        public Guid CustomerGuid { get; set; }




        [ForeignKey("CustomerGuid")]
        public virtual Customer.Entity.Customer Customer { get; set; }


        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();

    }
}
