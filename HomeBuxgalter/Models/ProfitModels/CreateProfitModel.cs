using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace HomeBuxgalter.Models.ProfitModels;

public class CreateProfitModel
{
    public long Amount { get; set; }
    public required DateTime Date { get; set; }
    public string? Comment { get; set; }
    [Required(ErrorMessage = "Category toldirilishi kerak")]
    public required string Category { get; set; }
}
