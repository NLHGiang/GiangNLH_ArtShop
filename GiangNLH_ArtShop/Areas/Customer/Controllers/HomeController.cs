﻿using GiangNLH.ArtShop.Services.Implements;
using GiangNLH.ArtShop.Services.Interfaces;
using GiangNLH_ArtShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GiangNLH.ArtShop.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IProductServices _productServices;

        public HomeController()
        {
            _productServices = new ProductServices();
        }

        public async Task<IActionResult> Index()
        {
            var list = await _productServices.GetAllAsync();
            ViewBag.listProduct = list.Where(c => c.Status != 1 && c.Amount > 5).Take(4).ToList();

            return View();
        }
        public IActionResult ProductList()
        {
            return View();
        }

        public IActionResult CartDetails()
        {
            return View();
        }

        public IActionResult BillList()
        {
            return View();
        }
    }
}