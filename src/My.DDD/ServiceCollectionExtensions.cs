using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace My.DDD
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Performs assembly scanning to add all implemented handlers for events.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assemblies"></param>
        /// <returns></returns>
        public static IServiceCollection AddDomainEvents(this IServiceCollection services, params Assembly[] assemblies)
        {
            var types = assemblies
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => !type.IsAbstract &&
                               !type.IsInterface)
                .Select(type => new { Handler = type, EventTypes = GetHandledEvents(type) })
                .Where(info => info.EventTypes.Any())
                .ToList();

            foreach (var info in types)
            {
                foreach (var eventType in info.EventTypes)
                {
                    services.AddTransient(typeof(IEventHandler<>).MakeGenericType(eventType), info.Handler);
                }
            }

            return services;
        }

        private static IEnumerable<Type> GetHandledEvents(Type handlerType)
        {
            return handlerType
                .FindInterfaces(
                    (t, _) => t.IsGenericType &&
                              t.GetGenericTypeDefinition() == typeof(IEventHandler<>),
                    null)
                .Select(t => t.GenericTypeArguments.First());
        }
    }
}
