using RedisExample.DAL.Models;

namespace RedisExample.DAL;

public interface IProductDAL
{
    Task AddProductAsync(ProductModel product);
    Task<ProductModel> GetProductAsync(int id);
    Task<List<ProductModel>> GetAllProductsAsync();
    
}