using JetBrains.Annotations;

using MAS.Framework.Core;

namespace MAS.Framework.Container
{
    public class ContainerFactory
    {
        [NotNull]
        public IServiceContainer Create() => new DryIocContainer();
    }
}