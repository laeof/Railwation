namespace Domain.Entities;

public class Country: BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public ICollection<CountryConnection> CountryConnections { get; set; }
    public ICollection<BorderCrossing> BorderCrossings { get; set; }

}
