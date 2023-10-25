using HomeBuxgalter.Entities;
using HomeBuxgalter.Managers.Interfaces;
using HomeBuxgalter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeBuxgalter.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OutlaysController : ControllerBase
{
    private readonly IOutlayManager<Outlay, CreateModel> _outlayManager;

    public OutlaysController(IOutlayManager<Outlay, CreateModel> outlayManager)
    {
        _outlayManager = outlayManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetOutlays()
    {
        try
        {
            var outlays = await _outlayManager.GetAllAsync();
            return Ok(outlays);
        }
        catch (Exception ex)
        {
            return BadRequest("So'rovga javob topilmadi qayta urinib ko'ring");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOulay([FromQuery]int id)
    {
        try
        {
            var outlay = await _outlayManager.GetAsync(id);
            return outlay == null ? NotFound("Bunday ma'lumot topilmadi") : Ok(outlay);
            
        }
        catch (Exception ex)
        {
            return BadRequest("So'rovga javob topilmadi, qayta urinib ko'ring!");
        }
    }
}
