using GiangNLH.ArtShop.Services.Implements;
using GiangNLH.ArtShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GiangNLH.ArtShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserPermissionController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly IRoleServices _roleServices;

        public UserPermissionController()
        {
            _userServices = new UserServices();
            _roleServices = new RoleServices();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
