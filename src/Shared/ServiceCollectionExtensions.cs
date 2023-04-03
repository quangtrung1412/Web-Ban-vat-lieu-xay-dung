using App.Shared.RetryPolicy;
using Microsoft.Extensions.DependencyInjection;

namespace App.Shared;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPolicy(this IServiceCollection services)
    => services.AddSingleton<IRetryPolicyFactory, RetryPolicyFactory>();
}