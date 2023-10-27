namespace HomeBuxgalterFront.Models.OutlayModels;

public class Outlay
{
    public int Id { get; set; }
    public long Amount { get; set; }
    public required DateTime Date { get; set; }
    public string? Comment { get; set; }
    public required string Category { get; set; }
}


