using MAS.Game.Core.Components.Cards;
using MAS.Game.Core.Effects.Creatures;
using MAS.Services.ECS;

namespace MAS.Game.Core
{
    internal class DeckCreator : IDeckCreator
    {
        public void Create(IEntityContainer container)
        {
            IEntity z1 = container.CreateEntity();
            z1.SetComponent(new MultiverseIdComponent(226747));

            z1.GetComponent<EffectStackComponent>().AddEffect(new DamageEffect(3));
        }
    }
}