using RedisCacheProject.DTO;
using RedisCacheProject.Models;

namespace RedisCacheProject.Services.Interface
{
    public interface IProductService
    {
        Task<List<ProductListDTO>> GetProducts(int page, int pageSize);
        Task<ProductItemDTO> GetProductById(int id);
        Task<ProductItemDTO> Create(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(int id);
    }
}
