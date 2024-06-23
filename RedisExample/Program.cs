using RedisExample.BLL;
using RedisExample.DAL;


var connection = new DbHelper();
connection.Database.EnsureCreated();
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IProductDAL, ProductDAL>();
builder.Services.AddScoped<IProductBLL, ProductBLL>();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost"; // Адрес вашего Redis сервера
    options.InstanceName = "local"; // Имя экземпляра (опционально)
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();


app.Run();
