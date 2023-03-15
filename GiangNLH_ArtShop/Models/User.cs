using GiangNLH.ArtShop.Models.EntityBase;
using System;
using System.Collections.Generic;

namespace GiangNLH_ArtShop.Models
{
    public partial class User : EntityBase
    {
        public Guid Id { get; set; }
        public Guid IdRole { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<CartDetails> CartDetails { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
