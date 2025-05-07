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

    public async Task<Result<IntegrationsScore>> ExecuteAsync(Guid countryId)
    {
        var countryResult = await countryRepository.GetCountryWithIdAsync(countryId);

        if (countryResult.IsFailure) return Result<IntegrationsScore>.Faillure(countryResult.Error);

        var citiesResult = await cityRepository.GetCitiesWithCountryIdAsync(countryId);

        if (countryResult.IsFailure) return Result<IntegrationsScore>.Faillure(countryResult.Error);

        var cityGraph = integrationService.BuildGraph(citiesResult.Value);

        var score = new IntegrationsScore();

        score.ScoreInternationalConnections = integrationService.ScoreInternationalConnections(countryResult.Value);
        score.ScoreRailServices = integrationService.ScoreRailServices(countryResult.Value);
        score.ScoreLogistics = integrationService.ScoreLogistics(countryResult.Value);
        score.ScoreBorderCrossings = integrationService.ScoreBorderCrossings(countryResult.Value);
        score.ScoreCityCoverage = integrationService.ScoreCityCoverage(citiesResult.Value, cityGraph);

        return Result<IntegrationsScore>.Success(score);
    }
}
