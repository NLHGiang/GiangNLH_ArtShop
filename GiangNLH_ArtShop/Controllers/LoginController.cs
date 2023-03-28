using GiangNLH.ArtShop.Models.ViewModels;
using GiangNLH.ArtShop.Services.Implements;
using GiangNLH.ArtShop.Services.Interfaces;
using GiangNLH_ArtShop.ArtShopDbContext;
using GiangNLH_ArtShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace GiangNLH.ArtShop.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserServices _userServices;
        List<User> listUser = new();

        public LoginController()
        {
            _userServices = new UserServices();
        }

        public async Task<IActionResult> Index(UserForLogin user)
        {
            return RedirectToAction("Index", "Home", new { area = "Customer" });

            //if (!string.IsNullOrEmpty(user.Username) && !string.IsNullOrEmpty(user.Password))
            //{
            //    await GetListUser();
            //    if (listUser.Any(c => c.Username == user.Username && c.Password == user.Password && c.IdRole != Guid.Parse("9871ad42-6960-473d-aa75-aabc6edf5014")))
            //    {
            //        return RedirectToAction("Index", "Home", new { area = "Admin" });
            //    }
            //    if (listUser.Any(c => c.Username == user.Username && c.Password == user.Password && c.IdRole == Guid.Empty))
            //    {
            //        return RedirectToAction("Index", "Home", new { area = "Customer" });
            //    }
            //}
            //return View();
        }

        public async Task<IActionResult> Register(UserForRegister user)
        {
            if (user != null)
            {
                User addedUser = new()
                {
                    Id = Guid.NewGuid(),
                    IdRole = Guid.Empty,
                    FullName = user.FullName,
                    Email = user.Email,
                    Username = user.Username,
                    Password = user.Password
                };

                var result = await _userServices.AddAsync(addedUser);

                if (result)
                {
                    return RedirectToAction("Index");
                }

                return View();
            }

            return View();
        }

        public async Task<IActionResult> ForgetPassword(UserForForgetPassword user)
        {
            return RedirectToAction("Index");

            if (user != null)
            {
                try
                {
                    await GetListUser();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return View();
                }
            }

            return View();
        }

        public async Task<IActionResult> ChangePassword(UserForChangePassword user)
        {
            if (user != null)
            {
                await GetListUser();

                User userForUpdate = listUser.FirstOrDefault(c => c.Username == user.Username);

                if (userForUpdate != null)
                {
                    userForUpdate.Password = user.NewPassword;

                    var result = await _userServices.UpdateAsync(userForUpdate.Id, userForUpdate);

                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                    return View();
                }
            }

            return View();
        }

        public async Task GetListUser()
        {
            listUser = new();
            listUser = await _userServices.GetAllAsync();
        }
    }
}
