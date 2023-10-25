namespace HomeBuxgalter.Models.ProfitModels;

public class CreateProfitModel
{
    public long Amount { get; set; }
    public required DateTime Date { get; set; }
    public string? Comment { get; set; }
    public required string Category { get; set; }
}
