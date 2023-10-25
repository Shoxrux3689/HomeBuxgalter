using HomeBuxgalter.Entities.Enums;

namespace HomeBuxgalter.Entities;

public class Entity
{
    public int Id { get; set; }
    public long Amount { get; set; }
    public required DateTime Date { get; set; }
    public string? Comment { get; set; }
}
