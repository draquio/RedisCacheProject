using AutoMapper;
using RedisCacheProject.DTO;
using RedisCacheProject.Models;
using System.Globalization;
namespace RedisCacheProject.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            #region Products
            CreateMap<Product, ProductItemDTO>()
                .ForMember(dto => dto.Price, options => options.MapFrom(product => product.Price.ToString()));

            CreateMap<Product, ProductListDTO>().ReverseMap();

            CreateMap<ProductCreateDTO, Product>()
                .ForMember(product => product.Price, options => options.MapFrom(dto => ConvertStringtoDecimal(dto.Price)));
            #endregion
        }

        private static decimal ConvertStringtoDecimal(string priceString)
        {
            if (decimal.TryParse(priceString, NumberStyles.Any, CultureInfo.InvariantCulture, out var price))
            {
                return price;
            }

            throw new ArgumentException($"El precio '{priceString}' no es válido.");
        }
    }
}
