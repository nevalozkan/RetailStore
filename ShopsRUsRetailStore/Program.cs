using ShopsRUsRetailStore.API.Models;
using ShopsRUsRetailStore.API.Services.Abstract;
using ShopsRUsRetailStore.API.Services.Concrete;
using System.Diagnostics.CodeAnalysis;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services);

// Add services to the container.

builder.Services.AddControllers();

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

void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<IInvoiceService, InvoiceService>();
    services.AddSingleton<IDiscountFactory, DiscountFactory>();
}


