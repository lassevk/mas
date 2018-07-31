using System;

using JetBrains.Annotations;

using MAS.Services.ECS;
using MAS.Services.Game;

namespace MAS.Game.Core
{
    internal class GameEngine : IGameEngine
    {
        [NotNull]
        private readonly IEntityContainer _EntityContainer;

        [NotNull]
        private readonly IDeckCreator _DeckCreator;

        public GameEngine([NotNull] IEntityContainer entityContainer, [NotNull] IDeckCreator deckCreator)
        {
            _EntityContainer = entityContainer ?? throw new ArgumentNullException(nameof(entityContainer));
            _DeckCreator = deckCreator ?? throw new ArgumentNullException(nameof(deckCreator));
        }

        public void Run()
        {
            _DeckCreator.Create(_EntityContainer);
        }
    }
}