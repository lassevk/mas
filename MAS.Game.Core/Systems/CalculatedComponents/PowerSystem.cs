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
    [UsedImplicitly]
    internal class PowerSystem : ISystem
    {
        public IEnumerable<Type> ReactsToComponentTypes() => new [] { typeof(StaticCreatureComponent), typeof(StaticPowerComponent), typeof(EffectStackComponent) };

        public void ComponentSet(IEntity entity, object component)
        {
            if (!entity.HasComponent<StaticCreatureComponent>())
                return;

            CalculatePower(entity);
        }

        private static void CalculatePower([NotNull] IEntity entity)
        {
            var basePower = entity.GetComponentOrDefault<StaticPowerComponent>()?.Value ?? 0;
            var adjustments = entity.GetComponentOrDefault<EffectStackComponent>()
                                ?.GetEffects()
                                ?.OfType<IPowerAdjustmentEffect>()
                                ?.Sum(pae => pae.Adjustment)
                           ?? 0;

            entity.SetComponent(new PowerComponent(basePower + adjustments));
        }

        public void ComponentRemoved(IEntity entity, object component)
        {
            if (!entity.HasComponent<StaticCreatureComponent>())
            {
                entity.RemoveComponent<PowerComponent>();
                return;
            }

            CalculatePower(entity);
        }
    }
}
