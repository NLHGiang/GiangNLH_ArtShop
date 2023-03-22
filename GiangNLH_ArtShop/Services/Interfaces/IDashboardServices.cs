using GiangNLH.ArtShop.Models.ViewModels;
using GiangNLH_ArtShop.Models;

namespace GiangNLH.ArtShop.Services.Interfaces
{
    public interface IDashboardServices
    {
        public Task<List<ProductForDashboard>> GetAllProductForDashboardAsync(DateTime start, DateTime end);
        public Task<List<CategoryForDashboard>> GetAllCategoryForDashboardAsync(DateTime start, DateTime end);
    }
}
