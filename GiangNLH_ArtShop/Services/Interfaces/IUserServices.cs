using GiangNLH_ArtShop.Models;

namespace GiangNLH.ArtShop.Services.Interfaces
{
    public interface IUserServices
    {
        public Task<List<User>> GetAllAsync();
        public Task<User> GetByIdAsync(Guid id);
        public Task<bool> AddAsync(User obj);
        public Task<bool> UpdateAsync(Guid id, User obj);
        public Task<bool> RemoveAsync(Guid id);
    }
}
