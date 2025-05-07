using Application.Common;
using Domain.Entities;

namespace Application.Interface.Service;

public interface IIntegrationService
{
    Dictionary<Guid, GraphCityNode> BuildGraph(List<City> cities);
    bool IsFullyConnected(Dictionary<Guid, GraphCityNode> graph);
    void DFS(Guid current, Dictionary<Guid, GraphCityNode> graph, HashSet<Guid> visited);
    int ScoreCityCoverage(List<City> cities, Dictionary<Guid, GraphCityNode> graph);
    int ScoreInternationalConnections(Country country);
    int ScoreRailServices(Country country);
    int ScoreLogistics(Country country);
    int ScoreBorderCrossings(Country country);
}
