namespace Domain.Entities;

public class City: BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public Guid CountryId { get; set; }
    public Country Country { get; set; }
    public ICollection<CityConnection> FromCityConnections { get; set; }
    public ICollection<CityConnection> ToCityConnections { get; set; }

}
