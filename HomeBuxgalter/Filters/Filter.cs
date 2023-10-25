using HomeBuxgalter.Filters.Enums;

namespace HomeBuxgalter.Filters;

public class Filter
{
    public string? CategoryName { get; set; }
    public long? StartAmount { get; set; }
    public long? EndAmount { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public EBy ByWhichTime { get; set; }   
}
