using HomeBuxgalter.Entities;
using HomeBuxgalter.Filters;
using HomeBuxgalter.Filters.Enums;
using HomeBuxgalter.Managers;
using HomeBuxgalter.Managers.Interfaces;
using HomeBuxgalter.Models;
using HomeBuxgalter.Models.OutlayModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeBuxgalter.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OutlaysController : ControllerBase
{
    private readonly IOutlayManager<Outlay, CreateOutlayModel, int> _outlayManager;
    private readonly IGenericManager<OutlayCategory, CreateOutlayCategory, short> _categoryManager;
    public OutlaysController(
        IOutlayManager<Outlay, CreateOutlayModel, int> 
        outlayManager, IGenericManager<OutlayCategory, CreateOutlayCategory, short> categoryManager)
    {
        _outlayManager = outlayManager;
        _categoryManager = categoryManager;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOutlayModel createModel)
    {
        try
        {
            var id = await _outlayManager.CreateAsync(createModel);
            return Created("", new { Id = id });
        }
        catch (Exception)
        {
            return BadRequest("Qayta urinib ko'ring");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetOutlays([FromQuery] OutlayFilter outlayFilter)
    {
        try
        {
            var outlays = await _outlayManager.GetAllAsync();
            return Ok(outlays);
        }
        catch (Exception)
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
        catch (Exception)
        {
            return BadRequest("So'rovga javob topilmadi, qayta urinib ko'ring!");
        }
    }

    [HttpGet("categories")]
    public async Task<IActionResult> GetCategories()
    {
        try
        {
            var outlayCategories = await _categoryManager.GetAllAsync();
            return Ok(outlayCategories);
        }
        catch
        {
            return BadRequest("Qayta urinib ko'ring");
        }
    }

    [HttpPost("categories")]
    public async Task<IActionResult> CreateCategory([FromBody] CreateOutlayCategory createOutlayCategory)
    {
        try
        {
            var id = await _categoryManager.CreateAsync(createOutlayCategory);
            return Ok(new {Id = id});
        }
        catch
        {
            return BadRequest("Qayta urinib ko'ring");
        }
    }
}
