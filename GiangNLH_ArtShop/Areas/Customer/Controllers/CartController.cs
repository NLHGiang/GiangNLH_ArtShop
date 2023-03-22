using GiangNLH.ArtShop.Services.Implements;
using GiangNLH.ArtShop.Services.Interfaces;
using GiangNLH_ArtShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GiangNLH.ArtShop.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly ICartDetailsServices _cartDetailsServices;

        public CartController()
        {
            _cartDetailsServices = new CartDetailsServices();
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.listCartDetails = await _cartDetailsServices.GetAllAsync();

            return View();
        }

        public async Task<IActionResult> Details(Guid idProduct, Guid idUser)
        {
            ViewBag.cartDetails = await _cartDetailsServices.GetByIdAsync(idProduct, idUser);

            return View();
        }

        public async Task<IActionResult> Create(CartDetails obj)
        {
            var result = await _cartDetailsServices.AddAsync(obj);

            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Update(CartDetails obj)
        {
            var result = await _cartDetailsServices.UpdateAsync(obj.IdProduct, obj.IdUser, obj);

            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Delete(Guid idProduct, Guid idUser)
        {
            ViewBag.listCartDetails = await _cartDetailsServices.RemoveAsync(idProduct, idUser);

            return RedirectToAction("Index");
        }
    }
}
