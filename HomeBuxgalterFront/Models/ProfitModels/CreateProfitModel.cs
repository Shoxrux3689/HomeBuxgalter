namespace HomeBuxgalterFront.Models.ProfitModels;

public class CreateProfitModel
{
    public long Amount { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public string? Comment { get; set; }
    public string? Category { get; set; }
}
