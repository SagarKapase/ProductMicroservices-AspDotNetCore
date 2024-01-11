using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using ProductMicroservices.DBContexts;
using ProductMicroservices.Repositories;
using ProductMicroservices.Repositories.impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEntityFrameworkMySQL().AddDbContext<ProductContext>
(options => options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ProductContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
