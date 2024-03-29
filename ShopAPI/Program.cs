using Microsoft.EntityFrameworkCore;
using ShopAPI.Interfaces;
using ShopAPI.Models;
using ShopAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Connection
builder.Services.AddDbContext<ShopDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add Cors
builder.Services.AddCors(options => options.AddPolicy(name: "ShopDecorOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:5100").AllowAnyMethod().AllowAnyHeader();
    }));

// Add Scope
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<IOfferRepo, OfferRepo>();
builder.Services.AddScoped<IPayMethodRepo, PayMethodRepo>();
builder.Services.AddScoped<IRoomRepo, RoomRepo>();
builder.Services.AddScoped<IProductRepo, ProductRepo>();

// Add Mapping
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use Cors
app.UseCors("ShopDecorOrigins");
app.UseAuthorization();

app.MapControllers();

app.Run();
