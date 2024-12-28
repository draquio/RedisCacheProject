﻿
using AutoMapper;
using RedisCacheProject.DTO;
using RedisCacheProject.Models;
using RedisCacheProject.Repository.Interface;
using RedisCacheProject.Services.Interface;

namespace RedisCacheProject.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductListDTO>> GetProducts(int page, int pageSize)
        {
            try
            {
                List<Product> products = await _repository.GetAllProducts(page, pageSize);
                if (products == null) return new List<ProductListDTO>();
                List<ProductListDTO> productsMapped = _mapper.Map<List<ProductListDTO>>(products);
                return productsMapped;
            }
            catch (ArgumentException) { throw; }
            catch (KeyNotFoundException) { throw; }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred:", ex);
            }
        }

        public async Task<ProductItemDTO> GetProductById(int id)
        {
            try
            {
                Product product = await _repository.GetById(id);
                if (product == null) throw new KeyNotFoundException($"Product with ID {id} not found");
                ProductItemDTO productDTO = _mapper.Map<ProductItemDTO>(product);
                return productDTO;
            }
            catch (ArgumentException) { throw; }
            catch (KeyNotFoundException) { throw; }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred:", ex);
            }
        }

        public Task<ProductItemDTO> Create(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
