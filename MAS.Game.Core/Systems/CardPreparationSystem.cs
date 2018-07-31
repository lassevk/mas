using System;
using System.Collections.Generic;

using JetBrains.Annotations;

using MAS.Game.Core.Components.Cards;
using MAS.Services.ECS;

namespace MAS.Game.Core.Systems
{
    [UsedImplicitly]
    internal class CardPreparationSystem : ISystem
    {
        public IEnumerable<Type> ReactsToComponentTypes() => new [] { typeof(CardComponent) };

        public void ComponentSet(IEntity entity, object component)
        {
            if (!entity.HasComponent<EffectStackComponent>())
                entity.SetComponent(new EffectStackComponent(entity));
        }

        public void ComponentRemoved(IEntity entity, object component)
        {
        }
    }
}
