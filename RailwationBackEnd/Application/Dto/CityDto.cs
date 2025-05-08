namespace Application.Dto;

public class CityDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string PhotoUrl { get; set; }
    public Guid CountryId { get; set; }
}
