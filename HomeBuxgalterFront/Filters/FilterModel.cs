namespace HomeBuxgalterFront.Filters;

public class FilterModel
{
    public DateTime StartDate { get; set; } = DateTime.Parse($"{DateTime.Now.Month}/1/{DateTime.Now.Year}");
    public DateTime EndDate { get; set; } = DateTime.Now;
}
