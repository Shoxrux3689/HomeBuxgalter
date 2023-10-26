using Microsoft.AspNetCore.Mvc;

namespace HomeBuxgalter.Filters;

public class ProfitFilter : Filter
{
    [FromQuery]
    public string? CategoryName { get; set; }
}
