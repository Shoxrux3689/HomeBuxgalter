using System.ComponentModel.DataAnnotations;

namespace HomeBuxgalter.Models.OutlayModels;

public class CreateOutlayModel
{
    public long Amount { get; set; }
    public required DateTime Date { get; set; }
    public string? Comment { get; set; }
    [Required(ErrorMessage = "Category toldirilishi kerak")]
    public required string Category { get; set; }
}
