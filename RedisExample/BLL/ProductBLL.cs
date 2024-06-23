using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using RedisExample.DAL;
using RedisExample.DAL.Models;

namespace RedisExample.BLL;

public class ProductBLL(IProductDAL productDal, IDistributedCache distributedCache): IProductBLL
{
    public async Task AddProductAsync(ProductModel product)
    {
        await productDal.AddProductAsync(product);
    }

    public async Task<ProductModel> GetProductAsync(int id)
    {
        return await productDal.GetProductAsync(id);
    }

    public async Task<List<ProductModel>> GetAllProductsAsync()
    {
        string cacheKey = "productList";
        string cachedProductList = await distributedCache.GetStringAsync(cacheKey);
        List<ProductModel> products;

        if (cachedProductList == null)
        {
            products = await productDal.GetAllProductsAsync();
            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(15));

            string serializedProductList = JsonConvert.SerializeObject(products);
            await distributedCache.SetStringAsync(cacheKey, serializedProductList, options);
            Console.WriteLine("DB");
            return products;
        }
        Console.WriteLine("cache");
        return JsonConvert.DeserializeObject<List<ProductModel>>(cachedProductList);
        
    }
}