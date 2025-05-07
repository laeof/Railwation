using Application.Common;
using Application.Interface.Repository;
using Application.Interface.Service;

namespace Application.UseCases;

public class CalculateIntegrationScoreUseCase
{
    private readonly IIntegrationService integrationService;
    private readonly ICountryRepository countryRepository;
    private readonly ICityRepository cityRepository;
    public CalculateIntegrationScoreUseCase(
        IIntegrationService integrationService,
        ICountryRepository countryRepository,
        ICityRepository cityRepository
        ) 
    { 
        this.integrationService = integrationService;
        this.countryRepository = countryRepository;
        this.cityRepository = cityRepository;
    }

    public async Task<Result<int>> ExecuteAsync(Guid countryId)
    {
        var countryResult = await countryRepository.GetCountryWithIdAsync(countryId);

        if (countryResult.IsFailure) return Result<int>.Faillure(countryResult.Error);

        var citiesResult = await cityRepository.GetCitiesWithCountryIdAsync(countryId);

        if (countryResult.IsFailure) return Result<int>.Faillure(countryResult.Error);

        var cityGraph = integrationService.BuildGraph(citiesResult.Value);

        int totalScore = 0;

        totalScore += integrationService.ScoreInternationalConnections(countryResult.Value);
        totalScore += integrationService.ScoreRailServices(countryResult.Value);
        totalScore += integrationService.ScoreLogistics(countryResult.Value);
        totalScore += integrationService.ScoreBorderCrossings(countryResult.Value);
        totalScore += integrationService.ScoreCityCoverage(citiesResult.Value, cityGraph);

        return Result<int>.Success(Math.Min(totalScore, 100));
    }
}
