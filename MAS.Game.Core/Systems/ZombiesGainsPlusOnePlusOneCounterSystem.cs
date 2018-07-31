using System;
using System.Collections.Generic;

using JetBrains.Annotations;

using MAS.Game.Core.Components.Cards;
using MAS.Game.Core.Components.Cards.Creatures;
using MAS.Game.Core.Effects.Creatures;
using MAS.Services.ECS;
using MAS.Services.Logging;

namespace MAS.Game.Core.Systems
{
    [UsedImplicitly]
    internal class ZombiesGainsPlusOnePlusOneCounterSystem : ISystem
    {
        [NotNull]
        private readonly ILogger _Logger;

        public ZombiesGainsPlusOnePlusOneCounterSystem([NotNull] ILogger logger)
        {
            _Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IEnumerable<Type> ReactsToComponentTypes()
            => new[] { typeof(StaticCreatureComponent), typeof(StaticCreatureTypeComponent) };

        public void ComponentSet(IEntity entity, object component)
        {
            var isCreature = entity.HasComponent<StaticCreatureComponent>();
            var isZombie = entity.GetComponentOrDefault<StaticCreatureTypeComponent>()?.Value.Contains("Zombie")
                        ?? false;

            if (isCreature && isZombie)
            {
                _Logger.Debug($"Zombie {entity} gains a +1/+1 counter");
                entity.GetComponent<EffectStackComponent>().AddEffect(new PlusOnePlusOneCounterEffect());
            }
        }

        public void ComponentRemoved(IEntity entity, object component)
        {
        }
    }
}