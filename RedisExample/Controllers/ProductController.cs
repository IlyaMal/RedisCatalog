using Microsoft.AspNetCore.Mvc;
using RedisExample.BLL;
using RedisExample.DAL.Models;

namespace RedisExample.Controllers;


[ApiController]
public class ProductController(IProductBLL productBll): ControllerBase
{
    [HttpPost("add")]
    public async Task<IActionResult> AddProduct([FromBody] ProductModel model)
    {
        await productBll.AddProductAsync(model);
        return Ok();
    }
    
    [HttpGet("/{id}")]
    public async Task<IActionResult> AddProduct(int id)
    {
        var model = await productBll.GetProductAsync(id);
        return Ok(model);
    }
    
    [HttpGet("/")]
    public async Task<IActionResult> GetProducts(int id)
    {
        var models = await productBll.GetAllProductsAsync();
        return Ok(models);
    }
}