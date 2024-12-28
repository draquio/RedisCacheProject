using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedisCacheProject.DTO;
using RedisCacheProject.Response;
using RedisCacheProject.Services.Interface;

namespace RedisCacheProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseProductList<List<ProductListDTO>>>> GetProducts(int page = 1, int pageSize = 10)
        {
            var rsp = new ResponseProductList<List<ProductListDTO>>();
            try
            {
                rsp.status = true;
                rsp.value = await _productService.GetProducts(page, pageSize);
                rsp.page = page;
                rsp.pageSize = pageSize;
                return Ok(rsp);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = $"An error occurred: {ex.Message}";
                return StatusCode(500, rsp);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ResponseProduct<ProductItemDTO>>> GetById(int id)
        {
            var rsp = new ResponseProduct<ProductItemDTO>();
            try
            {
                rsp.status = true;
                rsp.value = await _productService.GetProductById(id);
                return Ok(rsp);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = $"An error occurred: {ex.Message}";
                return StatusCode(500, rsp);
            }
        }
    }
}
