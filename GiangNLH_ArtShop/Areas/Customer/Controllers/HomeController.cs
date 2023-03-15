using GiangNLH_ArtShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GiangNLH.ArtShop.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
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