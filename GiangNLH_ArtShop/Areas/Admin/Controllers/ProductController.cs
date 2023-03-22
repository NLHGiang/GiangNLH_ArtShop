using GiangNLH.ArtShop.Services.Implements;
using GiangNLH.ArtShop.Services.Interfaces;
using GiangNLH_ArtShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GiangNLH.ArtShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;

        public ProductController()
        {
            _productServices = new ProductServices();
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.listProduct = await _productServices.GetAllAsync();

            return View();
        }

        public async Task<IActionResult> Details(Guid id)
        {
            ViewBag.product = await _productServices.GetByIdAsync(id);

            return View();
        }

        public async Task<IActionResult> Create(Product obj)
        {
            var result = await _productServices.AddAsync(obj);

            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Update(Product obj)
        {
            var result = await _productServices.UpdateAsync(obj.Id, obj);

            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            ViewBag.listProduct = await _productServices.RemoveAsync(id);

            return RedirectToAction("Index");
        }
    }
}
