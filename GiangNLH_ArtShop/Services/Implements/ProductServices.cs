﻿using GiangNLH.ArtShop.Services.Interfaces;
using GiangNLH_ArtShop.ArtShopDbContext;
using GiangNLH_ArtShop.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace GiangNLH.ArtShop.Services.Implements
{
    public class ProductServices : IProductServices
    {
        private readonly ArtShopContext _dbContext;

        public ProductServices()
        {
            this._dbContext = new ArtShopContext();
        }

        public async Task<bool> AddAsync(Product obj)
        {
            try
            {
                obj.CreatedTime = DateTime.Now;

                await _dbContext.Products.AddAsync(obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Product>> GetAllAsync()
        {
            var list = await _dbContext.Products.ToListAsync();

            return list;
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            var list = await _dbContext.Products.ToListAsync();
            var obj = list.FirstOrDefault(c => c.Id == id);

            return obj;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            try
            {
                var listObj = await _dbContext.Products.ToListAsync();
                var obj = listObj.FirstOrDefault(c => c.Id == id);
                obj.Status = 1;

                _dbContext.Products.Attach(obj);
                await Task.FromResult<Product>(_dbContext.Products.Update(obj).Entity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Guid id, Product obj)
        {
            try
            {
                var listObj = await _dbContext.Products.ToListAsync();
                var objForUpdate = listObj.FirstOrDefault(c => c.Id == id);


                objForUpdate.Name = obj.Name;
                objForUpdate.Price = obj.Price;
                objForUpdate.ReducedPrice = obj.ReducedPrice;
                objForUpdate.Amount = obj.Amount;
                objForUpdate.Image = obj.Image;
                objForUpdate.Status = obj.Status;

                _dbContext.Products.Attach(obj);
                await Task.FromResult<Product>(_dbContext.Products.Update(obj).Entity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
