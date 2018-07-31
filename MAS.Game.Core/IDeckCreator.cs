using JetBrains.Annotations;

using MAS.Services.ECS;

namespace MAS.Game.Core
{
    internal interface IDeckCreator
    {
        void Create([NotNull] IEntityContainer container);
    }
}
