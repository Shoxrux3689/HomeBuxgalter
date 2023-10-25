namespace HomeBuxgalter.Models;

public class CreateModel
{
    public long Amount { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public string? Comment { get; set; }
    public required string Category { get; set; }
    public bool IsProfit { get; set; }
}
