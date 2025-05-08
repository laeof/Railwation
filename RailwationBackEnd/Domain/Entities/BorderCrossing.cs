namespace Domain.Entities;

public class BorderCrossing: BaseEntity
{
    public Guid CountryAId { get; set; }
    public Country CountryA { get; set; }
    public Guid CountryBId { get; set; }
    public Country CountryB { get; set; }
    public City CityA { get; set; }
    public Guid CityAId { get; set; }
    public City CityB { get; set; }
    public Guid CityBId { get; set; }
    public bool HasRailway { get; set; }
}
