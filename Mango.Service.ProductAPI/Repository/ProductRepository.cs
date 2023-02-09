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
        public ProductRepository(ApplicationDBContext db, IMapper map)//we get this implementation from program.cs file 
        {
            _db = db;
            _mapper = map;
        }

        public  async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            //we get the ProductDto object while updating or creating 
            //we have to map it to Product 
            Product product =  _mapper.Map<ProductDto, Product>(productDto);

            //indicate Update is there 
            if(product.ProductId >0)
            {
                _db.Update(product);
            }
            else//else addition of product is there 
            {
                _db.Add(product);
            }
            await _db.SaveChangesAsync();
            //at last return back productDto , mapper will use to map product to productDto
            return _mapper.Map<Product, ProductDto>(product);

        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                //access that product through Id 
                Product product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
                //if product not found 
                if (product == null)
                    return false;

                //remove that product 
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
            //access the single product with Id
            Product product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            //map it with the ProductDto
            return _mapper.Map<ProductDto>(product);
            
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            //though this we get the data in the form of Product 
            List<Product> productList = await _db.Products.ToListAsync();

            //here we are map it to ProductDto 
            return _mapper.Map<List<ProductDto>>(productList);
             
        }
    }
}
