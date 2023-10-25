using HomeBuxgalter.Context;
using HomeBuxgalter.Entities;
using HomeBuxgalter.Entities.Enums;
using HomeBuxgalter.Managers;
using HomeBuxgalter.Managers.Interfaces;
using HomeBuxgalter.Models;
using HomeBuxgalter.Repositories;
using HomeBuxgalter.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IOutlayManager<Outlay, CreateModel>, OutlayManager>();
builder.Services.AddScoped<IOutlayRepository<Outlay>, OutlayRepository>();
builder.Services.AddScoped<IProfitManager<Profit, CreateModel>, ProfitManager>();
builder.Services.AddScoped<IProfitRepository<Profit>, ProfitRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("MyDb");
    //options.UseNpgsql(builder.Configuration.GetConnectionString("AppDbContext"));
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();