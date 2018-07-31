using JetBrains.Annotations;

namespace MAS.Framework.Core
{
    public interface IServiceRegistrar
    {
        void Register<[MeansImplicitUse] TService, [MeansImplicitUse] TConcrete>() where TConcrete : TService;
        void RegisterSingleton<[MeansImplicitUse] TService, [MeansImplicitUse] TConcrete>() where TConcrete : TService;
    }
}
