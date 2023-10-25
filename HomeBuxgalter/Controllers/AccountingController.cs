using HomeBuxgalter.Entities;
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
    private readonly IOutlayManager<Outlay, CreateOutlayModel> _outlayManager;
    private readonly IProfitManager<Profit, CreateProfitModel> _profitManager;

    public AccountingController(IOutlayManager<Outlay, CreateOutlayModel> outlayManager, IProfitManager<Profit, CreateProfitModel> profitManager)
    {
        _profitManager = profitManager;
        _outlayManager = outlayManager;
    }


}
