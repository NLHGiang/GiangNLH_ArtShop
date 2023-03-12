using GiangNLH.ArtShop.Models.EntityBase;
using System;
using System.Collections.Generic;

namespace GiangNLH_ArtShop.Models
{
    public partial class ProductCart : EntityBase
    {
        public Guid IdCart { get; set; }
        public Guid IdProduct { get; set; }
        public int Amount { get; set; }
        public virtual Product Product { get; set; }
        public virtual Cart Cart { get; set; }

    }
}
