namespace Domain.Entities;

public class BorderCrossing: BaseEntity
{
    public Guid CountryAId { get; set; }
    public Country CountryA { get; set; }
    public Guid CountryBId { get; set; }
    public Country CountryB { get; set; }
    public bool HasRailway { get; set; }
}
