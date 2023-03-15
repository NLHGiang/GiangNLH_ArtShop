using Microsoft.AspNetCore.Mvc;

namespace GiangNLH.ArtShop.Areas.Admin.Controllers
{
    [Area("Admin")]
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

        public IActionResult CartList()
        {
            return View();
        }        
        
        public IActionResult BillList()
        {
            return View();
        }

        public IActionResult UserList()
        {
            return View();
        }
    }
}
