using Application.Common;
using Application.Interface.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class BorderCrossingRepository : IBorderCrossingRepository
{
    private readonly AppDbContext context;
    public BorderCrossingRepository(AppDbContext context)
    {
        this.context = context;
    }
    public async Task<Result<BorderCrossing>> CreateBorderCrossingAsync(BorderCrossing borderCrossing)
    {
        try
        {
            context.Entry(borderCrossing).State = EntityState.Added;
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return Result<BorderCrossing>.Faillure(new("500", ex.Message));
        }

        return Result<BorderCrossing>.Success(borderCrossing);
    }

    public async Task<Result<List<BorderCrossing>>> GetBorderCrossingsWithCountryIdAsync(Guid id)
    {
        var borderCrossingsResult = await context.BorderCrossings
                .Where(b => b.CountryAId == id)
                .ToListAsync();

        if (borderCrossingsResult is null) return Result<List<BorderCrossing>>.Faillure(new("404", "Border crossings are not found"));

        return Result<List<BorderCrossing>>.Success(borderCrossingsResult);
    }
}
