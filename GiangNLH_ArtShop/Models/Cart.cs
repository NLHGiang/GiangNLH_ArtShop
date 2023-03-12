using GiangNLH.ArtShop.Models.EntityBase;
using System;
using System.Collections.Generic;

namespace GiangNLH_ArtShop.Models
{
    public partial class Cart : EntityBase
    {
        public Guid Id { get; set; }

        public Guid IdUser { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ProductCart> ProductCarts { get; set; }

    }
}
