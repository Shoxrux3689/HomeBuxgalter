using HomeBuxgalter.Entities;
using HomeBuxgalter.Managers.Interfaces;
using HomeBuxgalter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeBuxgalter.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfitsController : ControllerBase
{
    private readonly IProfitManager<Profit, CreateModel> _profitManager;

    public ProfitsController(IProfitManager<Profit, CreateModel> profitManager)
    {
        _profitManager = profitManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetProfits()
    {
        try
        {
            var profits = await _profitManager.GetAllAsync();
            return Ok(profits);
        }
        catch (Exception ex)
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
        catch(Exception ex)
        {
            return BadRequest("So'rovga javob topilmadi, qayta urinib ko'ring!");
        }
    }
}
