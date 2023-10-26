using HomeBuxgalter.Filters.Enums;
using Microsoft.AspNetCore.Mvc;

namespace HomeBuxgalter.Filters;

public class Filter
{
    [FromQuery]
    public string? CategoryName { get; set; }
    [FromQuery]
    public long? StartAmount { get; set; }
    [FromQuery]
    public long? EndAmount { get; set; }
    [FromQuery]
    public DateOnly? StartDate { get; set; }
    [FromQuery]
    public DateOnly? EndDate { get; set; }
    [FromQuery]
    public EBy ByWhichTime { get; set; }   
}
