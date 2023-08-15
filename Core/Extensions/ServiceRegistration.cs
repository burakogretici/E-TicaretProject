using Core.Utilities.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
        {
            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<IStorage, T>();
        }
    }
}
