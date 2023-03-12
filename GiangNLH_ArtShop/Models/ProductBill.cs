using GiangNLH.ArtShop.Models.EntityBase;
using System;
using System.Collections.Generic;

namespace GiangNLH_ArtShop.Models
{
    public partial class ProductBill : EntityBase
    {
        public Guid IdBill { get; set; }
        public Guid IdProduct { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public double ReducedPrice { get; set; }
        public virtual Product Product { get; set; }
        public virtual Bill Bill { get; set; }

    }
}
