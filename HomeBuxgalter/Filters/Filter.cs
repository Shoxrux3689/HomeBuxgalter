using HomeBuxgalter.Filters.Enums;
using Microsoft.AspNetCore.Mvc;

namespace HomeBuxgalter.Filters;

public class Filter
{
    [FromQuery]
    public long? StartAmount { get; set; }
    [FromQuery]
    public long? EndAmount { get; set; }
    [FromQuery]
    public DateTime StartDate { get; set; }
    [FromQuery]
    public DateTime EndDate { get; set; }
    [FromQuery]
}
