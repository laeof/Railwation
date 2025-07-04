﻿using Application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CalculateIntegrationScoreUseCase>();

        return services;
    }
}
