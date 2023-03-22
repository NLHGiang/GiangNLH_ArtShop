using GiangNLH.ArtShop.Services.Implements;
using GiangNLH.ArtShop.Services.Interfaces;
using GiangNLH_ArtShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GiangNLH.ArtShop.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class BillController : Controller
    {
        private readonly IBillServices _billServices;

        public BillController()
        {
            _billServices = new BillServices();
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.listBill = await _billServices.GetAllAsync();

            return View();
        }

        public async Task<IActionResult> Details(Guid id)
        {
            ViewBag.bill = await _billServices.GetByIdAsync(id);

            return View();
        }

        public async Task<IActionResult> Create(Bill obj)
        {
            var result = await _billServices.AddAsync(obj);

            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Update(Bill obj)
        {
            var result = await _billServices.UpdateAsync(obj.Id, obj);

            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            ViewBag.listBill = await _billServices.RemoveAsync(id);

            return RedirectToAction("Index");
        }
    }
}
