namespace Application.Dto;

public class BorderCrossDto
{
    public Guid CountryAId { get; set; }
    public Guid CountryBId { get; set; }
    public bool HasRailway { get; set; }
}
