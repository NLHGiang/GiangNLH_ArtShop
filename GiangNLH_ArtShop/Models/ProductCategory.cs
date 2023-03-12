using GiangNLH.ArtShop.Models.EntityBase;
using System;
using System.Collections.Generic;

namespace GiangNLH_ArtShop.Models
{
    public partial class ProductCategory : EntityBase
    {
        public Guid IdProduct { get; set; }
        public Guid IdCategory { get; set; }
        public virtual Product Product { get; set; }
        public virtual Category Category { get; set; }
    }
}
