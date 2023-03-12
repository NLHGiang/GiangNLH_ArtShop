using GiangNLH.ArtShop.Models.EntityBase;
using System;
using System.Collections.Generic;

namespace GiangNLH_ArtShop.Models
{
    public partial class Role : EntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}
