namespace MAS.Framework.Core
{
    public interface IServiceRegistrar
    {
        void Register<TService, TConcrete>() where TConcrete : TService;
        void RegisterSingleton<TService, TConcrete>() where TConcrete : TService;
    }
}
