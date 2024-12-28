using RedisCacheProject.Models;

namespace RedisCacheProject.Repository.Interface
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts(int page, int pageSize);
        Task<Product> GetById(int id);
        Task<Product> Create(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(int id);
    }
}
