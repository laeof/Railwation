namespace Application.Common;

public class GraphCityNode
{
    public Guid CityId { get; set; }
    public List<Guid> Neighbors { get; set; } = new();
}