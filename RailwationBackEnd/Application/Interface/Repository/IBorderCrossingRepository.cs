using Application.Common;
using Domain.Entities;

namespace Application.Interface.Repository;

public interface IBorderCrossingRepository
{
    Task<Result<List<BorderCrossing>>> GetBorderCrossingsAsync();
    Task<Result<List<BorderCrossing>>> GetBorderCrossingsWithCountryIdAsync(Guid id);
    Task<Result<BorderCrossing>> CreateBorderCrossingAsync(BorderCrossing borderCrossing);
}
