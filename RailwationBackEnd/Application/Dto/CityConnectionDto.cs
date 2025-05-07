namespace Application.Dto;

public class CityConnectionDto
{
    public Guid FromCityId { get; set; }
    public Guid ToCityId { get; set; }
    public bool IsPassenger { get; set; }
    public bool IsFreight { get; set; }
    public int FrequencyPerWeek { get; set; }
}
