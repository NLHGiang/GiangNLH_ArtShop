using GiangNLH.ArtShop.Models.ViewModels;
using GiangNLH_ArtShop.ArtShopDbContext;
using GiangNLH_ArtShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace GiangNLH.ArtShop.Controllers
{
    public class LoginController : Controller
    {
        private readonly ArtShopContext _dbContext;
        List<User> _users = new();

        public async Task<IActionResult> Index(UserForLogin user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.Username) && !string.IsNullOrEmpty(user.Password))
                {
                    await GetListUser();
                    if (_users.Any(c => c.Username == user.Username && c.Password == user.Password && c.IdRole != Guid.Empty))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    if (_users.Any(c => c.Username == user.Username && c.Password == user.Password && c.IdRole == Guid.Empty))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Customer" });
                    }
                }
                return View();
            }
            catch (Exception)
            {

                return View();
            }
        }

        public async Task<IActionResult> Register(User user, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (user != null)
            {
                try
                {
                    var addedUser = await _dbContext.Users.AddAsync(user, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    return View();
                }
            }

            return View();
        }

        public async Task<IActionResult> ForgetPassword(UserForForgetPassword user)
        {
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

        public async Task<IActionResult> ChangePassword(UserForChangePassword user, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (user != null)
            {
                try
                {
                    await GetListUser();

                    User userForUpdate = _users.FirstOrDefault(c=>c.Username == user.Username);
                    if (userForUpdate != null)
                    {
                        userForUpdate.Password = user.NewPassword;

                        _dbContext.Users.Attach(userForUpdate);
                        await Task.FromResult<User>(_dbContext.Users.Update(userForUpdate).Entity);
                        await _dbContext.SaveChangesAsync(cancellationToken);

                        return RedirectToAction("Index");
                    }                   
                }
                catch (Exception)
                {

                    return View();
                }
            }

            return View();
        }

        public async Task GetListUser()
        {
            _users = new();
            _users = await _dbContext.Users.ToListAsync();
        }
    }
}
