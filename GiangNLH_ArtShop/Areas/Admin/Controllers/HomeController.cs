using GiangNLH.ArtShop.Services.Implements;
using GiangNLH.ArtShop.Services.Interfaces;
using GiangNLH_ArtShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GiangNLH.ArtShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly IRoleServices _roleServices;
        private readonly IDashboardServices _dashboardServices;

        public HomeController()
        {
            _userServices = new UserServices();
            _roleServices = new RoleServices();
            _dashboardServices = new DashboardServices();
        }

        public async Task<IActionResult> Index(DateTime? startTime, DateTime? endTime)
        {
            if (startTime == null && endTime == null)
            {
                startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            }

            ViewBag.startTime = startTime;
            ViewBag.endTime = endTime;

            ViewBag.listProductInDashboard = await _dashboardServices.GetAllProductForDashboardAsync((DateTime)startTime, (DateTime)endTime);
            ViewBag.listCategoryInDashboard = await _dashboardServices.GetAllCategoryForDashboardAsync((DateTime)startTime, (DateTime)endTime);
            
            return View();
        }

        public IActionResult ProductList()
        {
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        public IActionResult CartList()
        {
            return RedirectToAction("Index", "Cart", new { area = "Admin" });
        }

        public IActionResult BillList()
        {
            return RedirectToAction("Index", "Bill", new { area = "Admin" });
        }

        public IActionResult UserList()
        {
            return RedirectToAction("Index", "User", new { area = "Admin" });
        }
    }
}
