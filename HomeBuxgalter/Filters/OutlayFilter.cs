using Microsoft.AspNetCore.Mvc;

namespace HomeBuxgalter.Filters;

public class OutlayFilter : Filter
{

    [FromQuery]
    public string? CategoryName { get; set; }
}
