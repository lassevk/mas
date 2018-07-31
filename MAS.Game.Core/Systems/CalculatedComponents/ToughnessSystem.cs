using System;
using System.Collections.Generic;
using System.Linq;

using JetBrains.Annotations;

using MAS.Game.Core.Components.Cards;
using MAS.Game.Core.Components.Cards.Creatures;
using MAS.Game.Core.Effects.Creatures;
using MAS.Services.ECS;

namespace MAS.Game.Core.Systems.CalculatedComponents
{
    internal class ToughnessSystem : ISystem
    {
        public IEnumerable<Type> ReactsToComponentTypes() => new [] { typeof(StaticCreatureComponent), typeof(StaticToughnessComponent), typeof(EffectStackComponent) };
        
        public void ComponentSet(IEntity entity, object component)
        {
            if (!entity.HasComponent<StaticCreatureComponent>())
                return;

            CalculateToughness(entity);
        }

        private void CalculateToughness([NotNull] IEntity entity)
        {
            var basePower = entity.GetComponentOrDefault<StaticToughnessComponent>()?.Value ?? 0;
            var adjustments = entity.GetComponentOrDefault<EffectStackComponent>()
                                ?.GetEffects()
                                ?.OfType<IToughnessAdjustmentEffect>()
                                 .Sum(pae => pae.Adjustment)
                           ?? 0;

            entity.SetComponent(new ToughnessComponent(basePower + adjustments));
        }

        public void ComponentRemoved(IEntity entity, object component)
        {
            if (component is StaticCreatureComponent)
            {
                entity.RemoveComponent<ToughnessComponent>();
                return;
            }

            CalculateToughness(entity);
        }
    }
}