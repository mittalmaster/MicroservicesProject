using AutoMapper;
using Mango.Service.ProductAPI.Models;
using Mango.Service.ProductAPI.Models.Dto;

namespace Mango.Service.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMap()
        {
            var mappingConfig = new MapperConfiguration(Config =>

            {
                Config.CreateMap<Product, ProductDto>();
                Config.CreateMap<ProductDto, Product>();
            });
            return mappingConfig;

        }
    }
}
