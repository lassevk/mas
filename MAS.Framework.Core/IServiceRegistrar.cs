using JetBrains.Annotations;

namespace MAS.Framework.Core
{
    [PublicAPI]
    public interface IServiceRegistrar
    {
        void Register<TService, TConcrete>() where TConcrete : TService;
        void RegisterSingleton<TService, TConcrete>() where TConcrete : TService;
    }
}
