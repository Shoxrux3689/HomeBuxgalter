using HomeBuxgalter.Entities;
using HomeBuxgalter.Managers.Interfaces;
using HomeBuxgalter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeBuxgalter.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountingController : ControllerBase
{
    private readonly IOutlayManager<Outlay, CreateModel> _outlayManager;
    private readonly IProfitManager<Profit, CreateModel> _profitManager;

    public AccountingController(IOutlayManager<Outlay, CreateModel> outlayManager, IProfitManager<Profit, CreateModel> profitManager)
    {
        _profitManager = profitManager;
        _outlayManager = outlayManager;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateModel createModel)
    {
        try
        {
            if (createModel.IsProfit == true)
            {
                var profitModelId = await _profitManager.CreateAsync(createModel);
                return Created("", new { Id = profitModelId });
            }
            var outlayModelId = await _outlayManager.CreateAsync(createModel);
            return Created("", new { Id = outlayModelId });
        }
        catch (Exception ex)
        {
            return BadRequest("Qayta urinib ko'ring");
        }
    }

}
