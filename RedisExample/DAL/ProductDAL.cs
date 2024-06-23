using Microsoft.EntityFrameworkCore;
using RedisExample.DAL.Models;

namespace RedisExample.DAL;

public class ProductDAL: IProductDAL
{
    public async Task AddProductAsync(ProductModel product)
    {
        var connection = new DbHelper();
        await connection.Products.AddAsync(product);
        await connection.SaveChangesAsync();
    }

    public async Task<ProductModel> GetProductAsync(int id)
    {
        var connection = new DbHelper();
        return await connection.Products.FindAsync(id) ?? new ProductModel();
    }

    public async Task<List<ProductModel>> GetAllProductsAsync()
    {
        var connection = new DbHelper();
        return await connection.Products.ToListAsync();
    }
}