namespace Domain.Entities;

public class CityCrossing: BaseEntity
{
    public Guid CityAId { get; set; }
    public Country CityA { get; set; }
    public Guid CityBId { get; set; }
    public Country CityB { get; set; }
    public bool HasRailway { get; set; }
}
