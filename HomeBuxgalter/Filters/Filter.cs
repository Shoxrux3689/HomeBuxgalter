using HomeBuxgalter.Filters.Enums;
using Microsoft.AspNetCore.Mvc;

namespace HomeBuxgalter.Filters;

public class Filter
{
    [FromQuery]
    public DateTime StartDate { get; set; }
    [FromQuery]
    public DateTime EndDate { get; set; }
}
