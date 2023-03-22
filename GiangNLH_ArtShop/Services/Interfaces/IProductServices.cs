using GiangNLH_ArtShop.Models;

namespace GiangNLH.ArtShop.Services.Interfaces
{
    public interface IProductServices
    {
        public Task<List<Product>> GetAllAsync();
        public Task<Product> GetByIdAsync(Guid id);
        public Task<bool> AddAsync(Product obj);
        public Task<bool> UpdateAsync(Guid id, Product obj);
        public Task<bool> RemoveAsync(Guid id);

    }
}
