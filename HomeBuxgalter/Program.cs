using HomeBuxgalter.Context;
using HomeBuxgalter.Entities;
using HomeBuxgalter.Managers;
using HomeBuxgalter.Managers.Interfaces;
using HomeBuxgalter.Models.OutlayModels;
using HomeBuxgalter.Models.ProfitModels;
using HomeBuxgalter.Repositories;
using HomeBuxgalter.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IOutlayManager<Outlay, CreateOutlayModel>, OutlayManager>();
builder.Services.AddScoped<IOutlayRepository<Outlay>, OutlayRepository>();
builder.Services.AddScoped<IProfitManager<Profit, CreateProfitModel>, ProfitManager>();
builder.Services.AddScoped<IProfitRepository<Profit>, ProfitRepository>();
builder.Services.AddScoped<IAccountingManager, AccountingManager>();


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("MyDb");
    //options.UseNpgsql(builder.Configuration.GetConnectionString("AppDbContext"));
});

var app = builder.Build();

app.UseCors(cors =>
{
    cors.AllowAnyOrigin()
        .AllowAnyOrigin()
        .AllowAnyMethod();
});

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();