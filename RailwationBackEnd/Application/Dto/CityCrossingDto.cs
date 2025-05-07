namespace Application.Dto;

public class CityCrossingDto
{
    public Guid CityAId { get; set; }
    public Guid CityBId { get; set; }
    public bool HasRailway { get; set; }
}
