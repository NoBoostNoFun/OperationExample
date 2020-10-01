using Domain.Workflow;
using Domain.Workflow.Operations;
using Domain.Workflow.Operations.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddClaimWorkflow(this IServiceCollection services) =>
            services
                .AddSingleton<IClaimOperation, RegisterOperation>()
                .AddSingleton<IClaimOperation, StartOperation>()
                .AddSingleton<IClaimOperation, ResolveOperation>()
                .AddSingleton<IClaimOperation, CloseOperation>()
                .AddSingleton<ClaimWorkflow>();
    }
}
