using MAS.Services.ECS;

namespace MAS.Framework.ECS
{
    internal class EntityContainer : IEntityContainer
    {
        public IEntity CreateEntity() => new Entity(this);
    }
}