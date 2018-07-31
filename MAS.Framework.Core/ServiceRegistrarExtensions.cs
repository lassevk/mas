using System;

using JetBrains.Annotations;

namespace MAS.Framework.Core
{
    public static class ServiceRegistrarExtensions
    {
        [NotNull]
        public static IServiceRegistrar Bootstrap<T>([NotNull] this IServiceRegistrar registrar)
            where T: IServicesBootstrapper, new()
        {
            if (registrar == null)
                throw new ArgumentNullException(nameof(registrar));

            var bootstrapper = new T();
            bootstrapper.Bootstrap(registrar);
            return registrar;
        }
    }
}