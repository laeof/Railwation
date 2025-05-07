namespace Domain.Entities;

public class CityConnection: BaseEntity
{
    public Guid FromCityId { get; set; }
    public City FromCity { get; set; }

    public Guid ToCityId { get; set; }
    public City ToCity { get; set; }

    public bool IsPassenger { get; set; }
    public bool IsFreight { get; set; }
    public int FrequencyPerWeek { get; set; }
}
