using JetBrains.Annotations;

namespace MAS.Services.ECS
{
    [PublicAPI]
    public interface IEntityContainer
    {
        IEntity CreateEntity();
    }
}
