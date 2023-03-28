using GiangNLH.ArtShop.Services.Implements;
using GiangNLH.ArtShop.Services.Interfaces;
using GiangNLH_ArtShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GiangNLH.ArtShop.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;

        public ProductController()
        {
            _productServices = new ProductServices();
            _categoryServices = new CategoryServices();
        }

        public async Task<IActionResult> Index()
        {
            var list = await _productServices.GetAllAsync();
            ViewBag.listProduct = list.Where(c => c.Status != 1 && c.Amount > 5).Take(4).ToList();

            return View();
        }

        public async Task<IActionResult> Details(Guid id)
        {
            ViewBag.product = await _productServices.GetByIdAsync(id);
            ViewBag.listCategory = await _categoryServices.GetAllAsync();

            ViewData["Title"] = ViewBag.product.Name;

            return View();
        }
    }
}
