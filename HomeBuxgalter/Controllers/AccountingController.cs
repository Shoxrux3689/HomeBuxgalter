using HomeBuxgalter.Entities;
using HomeBuxgalter.Filters;
using HomeBuxgalter.Managers.Interfaces;
using HomeBuxgalter.Models;
using HomeBuxgalter.Models.OutlayModels;
using HomeBuxgalter.Models.ProfitModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeBuxgalter.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountingController : ControllerBase
{
    private readonly IAccountingManager _accountingManager;

    public AccountingController(IAccountingManager accountingManager)
    {
        _accountingManager = accountingManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAccounting([FromQuery] Filter filter)
    {
        try
        {
            var reportModels = await _accountingManager.GetAccounting(filter);
            return Ok(reportModels);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
