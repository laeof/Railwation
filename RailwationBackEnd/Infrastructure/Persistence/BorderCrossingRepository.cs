using Application.Common;
using Application.Interface.Repository;
using Domain.Entities;

namespace Infrastructure.Persistence;

internal class BorderCrossingRepository : IBorderCrossingRepository
{
    public Task<Result<BorderCrossing>> CreateBorderCrossingAsync(BorderCrossing borderCrossing)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<BorderCrossing>>> GetBorderCrossingsWithCountryIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
