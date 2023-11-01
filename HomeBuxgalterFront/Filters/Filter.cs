namespace HomeBuxgalterFront.Filters;

public class Filter : FilterModel
{
    public long StartAmount { get; set; }
    public long? EndAmount { get; set; }
    public string? CategoryName { get; set; }
}
