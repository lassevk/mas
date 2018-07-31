using System;
using System.Collections.Generic;

using MAS.Game.Core.Components.Cards;
using MAS.Game.Core.Components.Cards.Creatures;
using MAS.Game.Core.Effects.Creatures;
using MAS.Services.ECS;

namespace MAS.Game.Core.Systems
{
    internal class CardDetailsProviderSystem : ISystem
    {
        public IEnumerable<Type> ReactsToComponentTypes() => new[] { typeof(MultiverseIdComponent) };

        public void ComponentSet(IEntity entity, object component)
        {
            var id = ((MultiverseIdComponent)component).Value;

            switch (id)
            {
                case 226747:
                    entity.SetComponent(CardComponent.Instance);
                    entity.SetComponent(new StaticNameComponent("Diregraf Ghoul"));
                    entity.SetComponent(new StaticCreatureTypeComponent("Zombie"));
                    entity.SetComponent(new StaticPowerComponent(2));
                    entity.SetComponent(new StaticToughnessComponent(2));
                    entity.SetComponent(new StaticCastingCostComponent("B"));
                    entity.SetComponent(StaticCreatureComponent.Instance);
                    break;

                default:
                    throw new InvalidOperationException($"Unknown Multiverse id component added: {id}");
            }
        }

        public void ComponentRemoved(IEntity entity, object component)
        {
            
        }
    }
}