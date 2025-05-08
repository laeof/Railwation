namespace Domain.Entities;

public class Country: BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string PhotoUrl { get; set; } = "https://content.unops.org/photos/Generic/Impact/_image2880x1400/Ukraine-GettyImages-622892200.jpg";
    public ICollection<CountryConnection> FromCountryConnections { get; set; }
    public ICollection<CountryConnection> ToCountryConnections { get; set; }
    public ICollection<BorderCrossing> BorderCrossingsAsA { get; set; }
    public ICollection<BorderCrossing> BorderCrossingsAsB { get; set; }

}
