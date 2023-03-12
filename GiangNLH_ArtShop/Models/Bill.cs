using GiangNLH.ArtShop.Models.EntityBase;
using System;
using System.Collections.Generic;

namespace GiangNLH_ArtShop.Models
{
    public partial class Bill : EntityBase
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ProductBill> ProductBills { get; set; }
    }
}
