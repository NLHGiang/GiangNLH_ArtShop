using GiangNLH_ArtShop.Models;

namespace GiangNLH.ArtShop.Services.Interfaces
{
    public interface ICartDetailsServices
    {
        public Task<List<CartDetails>> GetAllAsync();
        public Task<CartDetails> GetByIdAsync(Guid idProduct, Guid idUser);
        public Task<bool> AddAsync(CartDetails obj);
        public Task<bool> UpdateAsync(Guid idProduct, Guid idUser, CartDetails obj);
        public Task<bool> RemoveAsync(Guid idProduct, Guid idUser);
        public Task<List<CartDetails>> GetAllOfUserAsync(Guid idUser);
    }
}
