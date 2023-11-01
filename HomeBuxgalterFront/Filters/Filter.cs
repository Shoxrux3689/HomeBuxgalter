namespace HomeBuxgalterFront.Filters;

public class Filter
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public long StartAmount { get; set; }
    public long? EndAmount { get; set; }
    public string? CategoryName { get; set; }
}
