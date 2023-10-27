using HomeBuxgalterFront.Filters.Enums;

namespace HomeBuxgalterFront.Filters;

public class AccountingFilter
{
    public long? StartAmount { get; set; }
    public long? EndAmount { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Parse($"{DateTime.Now.Month}/1/{DateTime.Now.Year}");
    public DateTime EndDate { get; set; } = DateTime.Now;
    public EBy ByWhichTime { get; set; }


    public override string ToString()
    {
        string urlQuery = $"{StartAmount}={StartAmount}&{EndAmount}={EndAmount}&" +
            $"{StartDate}={StartDate}&{EndDate}={EndDate}&{ByWhichTime}={ByWhichTime}";

        return urlQuery;
    }
}
