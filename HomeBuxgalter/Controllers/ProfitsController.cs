using HomeBuxgalter.Entities;
using HomeBuxgalter.Filters;
using HomeBuxgalter.Managers;
using HomeBuxgalter.Managers.Interfaces;
using HomeBuxgalter.Models;
using HomeBuxgalter.Models.ProfitModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeBuxgalter.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfitsController : ControllerBase
{
    private readonly IProfitManager<Profit, CreateProfitModel, int> _profitManager;
    private readonly ICategoryManager<ProfitCategory, CreateProfitCategory, short> _categoryManager;

    public ProfitsController(
        IProfitManager<Profit, CreateProfitModel, int> profitManager, 
        ICategoryManager<ProfitCategory, CreateProfitCategory, short> genericManager)
    {
        _profitManager = profitManager;
        _categoryManager = genericManager;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProfitModel createModel)
    {
        try
        {
            var id = await _profitManager.CreateAsync(createModel);
            return Created("", new { Id = id });
            
        }
        catch (Exception)
        {
            return BadRequest("Qayta urinib ko'ring");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetProfits([FromQuery] ProfitFilter profitFilter)
    {
        try
        {
            var profits = await _profitManager.GetProfitsAsync(profitFilter);
            return Ok(profits);
        }
        catch (Exception)
        {
            return BadRequest("So'rovga javob topilmadi, qayta urinib ko'ring!");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProfit(int id)
    {
        try
        {
            var profit = await _profitManager.GetAsync(id);
            return profit == null ? NotFound("Bunday ma'lumot topilmadi") : Ok(profit);
        }
        catch(Exception)
        {
            return BadRequest("So'rovga javob topilmadi, qayta urinib ko'ring!");
        }
    }

	[HttpGet("categories")]
	public async Task<IActionResult> GetCategories()
	{
        try
        {
            var profitCategories = await _categoryManager.GetAllAsync();
            return Ok(profitCategories);
        }
        catch
        {
            return BadRequest("Qayta urinib ko'ring");
        }
	}

	[HttpPost("categories")]
	public async Task<IActionResult> CreateCategory([FromBody] CreateProfitCategory createProfitCategory) 
	{
        try
        {
            var id = await _categoryManager.CreateAsync(createProfitCategory);
            return Ok(new {Id = id});
        }
        catch
        {
            return BadRequest("Qayta urinib ko'ring");
        }
	}
}
