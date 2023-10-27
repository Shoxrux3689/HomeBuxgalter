namespace HomeBuxgalterFront.Filters;

public class AccountingFilter
{
    public long? StartAmount { get; set; }
    public long? EndAmount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public EBy ByWhichTime { get; set; }
}
