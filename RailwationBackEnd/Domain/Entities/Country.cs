namespace Domain.Entities;

public class Country: BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public ICollection<CountryConnection> FromCountryConnections { get; set; }
    public ICollection<CountryConnection> ToCountryConnections { get; set; }
    public ICollection<BorderCrossing> BorderCrossingsAsA { get; set; }
    public ICollection<BorderCrossing> BorderCrossingsAsB { get; set; }

}
