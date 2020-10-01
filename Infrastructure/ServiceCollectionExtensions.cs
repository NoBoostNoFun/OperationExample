using System.Threading.Channels;
using Domain.Facade;
using Domain.Notifications;
using Infrastructure.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNotifications(this IServiceCollection services) =>
            services
                .AddSingleton(Channel.CreateUnbounded<Notification>())
                .AddSingleton<INotifier, ConsoleNotifier>()
                .AddSingleton<INotificationBus, NotificationBus>()
                .AddHostedService<NotificationProcessor>();

        public static IServiceCollection AddClaimRepository(this IServiceCollection services) =>
            services
                .AddMemoryCache()
                .AddSingleton<IClaimRepository, ClaimRepository>();
    }
}