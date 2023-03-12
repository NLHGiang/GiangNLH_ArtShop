﻿using GiangNLH.ArtShop.Models.EntityBase;
using System;
using System.Collections.Generic;

namespace GiangNLH_ArtShop.Models
{
    public partial class Product : EntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double ReducedPrice { get; set; }
        public int Amount { get; set; }
        public string Image { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        public virtual ICollection<ProductCart> ProductCarts { get; set; }
        public virtual ICollection<ProductBill> ProductBills { get; set; }

    }
}