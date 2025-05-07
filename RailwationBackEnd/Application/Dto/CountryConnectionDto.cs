namespace Application.Dto;

public class CountryConnectionDto
{
    public Guid FromCountryId { get; set; }
    public Guid ToCountryId { get; set; }

    public bool HasPassengerService { get; set; }
    public bool HasFreightService { get; set; }
    public int WeeklyFrequency { get; set; }
    public int LogisticsScore { get; set; }
}
