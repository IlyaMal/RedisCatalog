using RedisExample.DAL.Models;

namespace RedisExample.BLL;

public interface IProductBLL
{
    Task AddProductAsync(ProductModel product);
    Task<ProductModel> GetProductAsync(int id);
    Task<List<ProductModel>> GetAllProductsAsync();
}