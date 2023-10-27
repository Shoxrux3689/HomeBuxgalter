using Microsoft.AspNetCore.Mvc;

namespace HomeBuxgalter.Filters;

public class ProfitFilter : Filter
{
    [FromQuery]
    public long StartAmount { get; set; }
    [FromQuery]
    public long? EndAmount { get; set; }
    [FromQuery]
    public string? CategoryName { get; set; }
}
