using HomeBuxgalter.Entities.Enums;

namespace HomeBuxgalter.Entities;

public class Entity
{
    public int Id { get; set; }
    public long Amount { get; set; }
    public DateTime Date { get; set; }
    public string? Comment { get; set; }
}
