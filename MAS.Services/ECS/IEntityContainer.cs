using JetBrains.Annotations;

namespace MAS.Services.ECS
{
    public interface IEntityContainer
    {
        [NotNull]
        IEntity CreateEntity();
    }
}