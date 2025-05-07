using Application.Common;
using Application.Interface.Service;
using Domain.Entities;

namespace Infrastructure.Service;

public class IntegrationService : IIntegrationService
{
    public Dictionary<Guid, GraphCityNode> BuildGraph(List<City> cities)
    {
        var graph = new Dictionary<Guid, GraphCityNode>();

        foreach (var city in cities)
        {
            if (!graph.ContainsKey(city.Id))
                graph[city.Id] = new GraphCityNode { CityId = city.Id };

            foreach (var conn in city.CityConnections)
            {
                Guid neighborId = conn.FromCityId == city.Id ? conn.ToCityId : conn.FromCityId;

                if (!graph.ContainsKey(neighborId))
                    graph[neighborId] = new GraphCityNode { CityId = neighborId };

                graph[city.Id].Neighbors.Add(neighborId);
                graph[neighborId].Neighbors.Add(city.Id);
            }
        }

        return graph;
    }

    public bool IsFullyConnected(Dictionary<Guid, GraphCityNode> graph)
    {
        if (!graph.Any()) return false;

        var visited = new HashSet<Guid>();
        var startId = graph.Keys.First();

        DFS(startId, graph, visited);

        return visited.Count == graph.Count;
    }

    public void DFS(Guid current, Dictionary<Guid, GraphCityNode> graph, HashSet<Guid> visited)
    {
        if (visited.Contains(current)) return;

        visited.Add(current);

        foreach (var neighbor in graph[current].Neighbors)
        {
            DFS(neighbor, graph, visited);
        }
    }

    public int ScoreCityCoverage(List<City> cities, Dictionary<Guid, GraphCityNode> graph)
    {
        if (!cities.Any()) return 0;

        int connected = graph.Values.Count(node => node.Neighbors.Count > 0);
        double coverageRatio = (double)connected / cities.Count;
        int score = (int)(coverageRatio * 10); // макс 10 баллов

        if (IsFullyConnected(graph))
            score += 5; // бонус за полную связность

        return Math.Min(score, 15);
    }

    public int ScoreInternationalConnections(Country country)
    {
        var distinctConnections = country.CountryConnections?
            .Select(c => c.ToCountryId)
            .Distinct()
            .Count() ?? 0;

        return Math.Min(distinctConnections * 5, 25);
    }

    public int ScoreRailServices(Country country)
    {
        var connections = country.CountryConnections ?? new List<CountryConnection>();

        int passenger = connections.Count(c => c.HasPassengerService);
        int freight = connections.Count(c => c.HasFreightService);

        return Math.Min(passenger * 2, 10) + Math.Min(freight * 2, 10);
    }

    public int ScoreLogistics(Country country)
    {
        var connections = country.CountryConnections ?? new List<CountryConnection>();

        int totalFrequency = connections.Sum(c => c.WeeklyFrequency);
        int avgLogistics = connections.Any() ? (int)connections.Average(c => c.LogisticsScore) : 0;

        int freqScore = Math.Min(totalFrequency / 10, 20);
        int logisticsScore = Math.Min(avgLogistics, 10);

        return freqScore + logisticsScore;
    }

    public int ScoreBorderCrossings(Country country)
    {
        int railwayCrossings = country.BorderCrossings?
            .Count(b => b.HasRailway) ?? 0;

        return Math.Min(railwayCrossings * 3, 15);
    }
}
