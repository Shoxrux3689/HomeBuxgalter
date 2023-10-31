using HomeBuxgalterFront.Filters.Enums;

namespace HomeBuxgalterFront.Filters;

public class AccountingFilter
{
    public DateTime StartDate { get; set; } = DateTime.Parse($"{DateTime.Now.Month}/1/{DateTime.Now.Year}");
    public DateTime EndDate { get; set; } = DateTime.Now;
    public EBy ByWhichTime { get; set; }

    public override string ToString()
    {
        EndDate = DateTime.Parse($"{EndDate.Month}/{EndDate.Day}/{EndDate.Year} 23:59:59");
        var urlQuery = $"StartDate={StartDate.ToShortDateString()}&EndDate={EndDate.ToString()}&ByWhichTime={ByWhichTime}";
        
        return urlQuery;
    }
}
