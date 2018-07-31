using System;

using JetBrains.Annotations;

using MAS.Game.Core.Components.Cards;
using MAS.Services.ECS;
using MAS.Services.Logging;

namespace MAS.Game.Core
{
    [UsedImplicitly]
    internal class DeckCreator : IDeckCreator
    {
        [NotNull]
        private readonly ILogger _Logger;

        public DeckCreator([NotNull] ILogger logger)
        {
            _Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Create(IEntityContainer container)
        {
            IEntity z1 = container.CreateEntity();
            z1.SetComponent(new MultiverseIdComponent(226747));
        }
    }
}