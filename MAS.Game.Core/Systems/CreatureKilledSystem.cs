using System;
using System.Collections.Generic;

using MAS.Game.Core.Components.Cards.Creatures;
using MAS.Services.ECS;

namespace MAS.Game.Core.Systems
{
    internal class CreatureKilledSystem : ISystem
    {
        public IEnumerable<Type> ReactsToComponentTypes() => new [] { typeof(ToughnessComponent) };

        public void ComponentSet(IEntity entity, object component)
        {
            if (entity.GetComponent<ToughnessComponent>().Value <= 0)
                entity.SetComponent(CreatureDiedComponent.Instance);
        }

        public void ComponentRemoved(IEntity entity, object component)
        {
        }
    }
}
