using Microsoft.EntityFrameworkCore;
using RedisCacheProject.Context;
using RedisCacheProject.Models;
using RedisCacheProject.Repository.Interface;

namespace RedisCacheProject.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDBContext _dbContext;

        public ProductRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetAllProducts(int page, int pageSize)
        {
            try
            {
                List<Product> products = await _dbContext.Set<Product>()
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
                return products;
            }
            catch
            {
                throw;
            }
        }
        public async Task<Product> GetById(int id)
        {
            try
            {
                Product? product = await _dbContext.Set<Product>().FindAsync(id);
                return product;
            }
            catch
            {
                throw;
            }
        }
        public Task<Product> Create(Product product)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Update(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
