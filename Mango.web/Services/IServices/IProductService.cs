using Mango.web.Models;

namespace Mango.web.Services.IServices
{
    public interface IProductService
    {
        Task<T> GetAllProductsAsync<T>();
        Task<T> GetProductAsync<T>(int id);
        Task<T> UpdateProductAsync<T>(ProductDto productDto);
        Task<T> DeleteProductAsync<T>(int id);
        Task<T> CreateProductAsync<T>(ProductDto productDto);


    }
}
