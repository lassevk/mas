using DryIoc;
using MAS.Framework.Core;

namespace MAS.Framework.Container
{
    internal class DryIocContainer : IServiceContainer
    {
        private readonly DryIoc.Container _Container;

        public DryIocContainer()
        {
            _Container = new DryIoc.Container(rules => rules.NotNull().WithAutoConcreteTypeResolution());
        }

        public void Register<TService, TConcrete>()
            where TConcrete: TService
            => _Container.Register<TService, TConcrete>();

        public void RegisterSingleton<TService, TConcrete>()
            where TConcrete: TService
            => _Container.Register<TService, TConcrete>(Reuse.Singleton);

        public T Resolve<T>()
            where T: class
            => _Container.Resolve<T>().NotNull();
    }
}