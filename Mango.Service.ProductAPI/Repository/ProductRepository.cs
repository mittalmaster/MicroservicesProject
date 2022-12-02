using AutoMapper;
using Mango.Service.ProductAPI.DBContexts;
using Mango.Service.ProductAPI.Models;

namespace Mango.Service.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _db;
        private IMapper _map;
        public ProductRepository(ApplicationDBContext db, IMapper map)
        {
            _db = db;
            _map = map;
        }

        public Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
