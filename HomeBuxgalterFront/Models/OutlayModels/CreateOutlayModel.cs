namespace HomeBuxgalterFront.Models.OutlayModels;

public class CreateOutlayModel
{
    public long Amount { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public string? Comment { get; set; }
    public string? Category { get; set; }
}
