using GiangNLH_ArtShop.Models;

namespace GiangNLH.ArtShop.Services.Interfaces
{
    public interface ICategoryServices
    {
        public Task<List<Category>> GetAllAsync();
        public Task<Category> GetByIdAsync(Guid id);
        public Task<bool> AddAsync(Category obj);
        public Task<bool> UpdateAsync(Guid id, Category obj);
        public Task<bool> RemoveAsync(Guid id);

    }
}
