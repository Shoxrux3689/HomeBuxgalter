namespace HomeBuxgalterFront.Filters;

public class Filter : FilterModel
{
    public long StartAmount { get; set; }
    public long? EndAmount { get; set; }
    public string? CategoryName { get; set; }

    public override string ToString()
    {
        EndDate = DateTime.Parse($"{EndDate.Month}/{EndDate.Day}/{EndDate.Year} 23:59:59");
        var urlQuery = $"StartDate={StartDate.ToShortDateString()}&EndDate={EndDate.ToString()}&" +
            $"StartAmount={StartAmount}&EndAmount={EndAmount}&CategoryName={CategoryName}";

        return urlQuery;
    }
}
