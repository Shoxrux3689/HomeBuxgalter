using HomeBuxgalter.Filters.Enums;
using Microsoft.AspNetCore.Mvc;

namespace HomeBuxgalter.Filters;

public class AccountingFilter : Filter
{
    [FromQuery]
    public EBy ByWhichTime { get; set; }
}
