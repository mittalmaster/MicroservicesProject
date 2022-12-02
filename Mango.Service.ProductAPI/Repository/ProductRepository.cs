using AutoMapper;
using Mango.Service.ProductAPI.DBContexts;
using Mango.Service.ProductAPI.Models;
using Mango.Service.ProductAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Mango.Service.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _db;
        private IMapper _mapper;
        public ProductRepository(ApplicationDBContext db, IMapper map)
        {
            _db = db;
            _mapper = map;
        }

        public  async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product =  _mapper.Map<ProductDto, Product>(productDto);

            if(product.ProductId >0)
            {
                _db.Update(product);
            }
            else
            {
                _db.Add(product);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(product);

        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
                if (product == null)
                    return false;
                _db.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);
            
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> productList = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);
             
        }
    }
}
