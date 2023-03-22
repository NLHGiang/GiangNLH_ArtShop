using GiangNLH_ArtShop.Models;

namespace GiangNLH.ArtShop.Services.Interfaces
{
    public interface IProductBillServices
    {
        public Task<List<ProductBill>> GetAllAsync();
        public Task<ProductBill> GetByIdAsync(Guid idBill, Guid idProduct);
        public Task<bool> AddAsync(ProductBill obj);
        public Task<bool> UpdateAsync(Guid idBill, Guid idProductProduct, ProductBill obj);
        public Task<bool> RemoveAsync(Guid idBill, Guid idProduct);

    }
}
