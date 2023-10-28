using HomeBuxgalter.Entities;
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

    public ProfitsController(IProfitManager<Profit, CreateProfitModel, int> profitManager)
    {
        _profitManager = profitManager;
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
    public async Task<IActionResult> GetProfits()
    {
        try
        {
            var profits = await _profitManager.GetAllAsync();
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
		return Ok();
	}

	[HttpPost("categories")]
	public async Task<IActionResult> CreateCategory()
	{
		return Ok();
	}
}
