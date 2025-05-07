namespace Domain.Entities;

public class CountryConnection: BaseEntity
{
    public Guid FromCountryId { get; set; }
    public Country FromCountry { get; set; }
    public Guid ToCountryId { get; set; }
    public Country ToCountry { get; set; }

    public bool HasPassengerService { get; set; }
    public bool HasFreightService { get; set; }
    public int WeeklyFrequency { get; set; }
    public int LogisticsScore { get; set; } 
}
