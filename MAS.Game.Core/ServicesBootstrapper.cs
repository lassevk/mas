using MAS.Framework.Core;
using MAS.Game.Core.Systems;
using MAS.Game.Core.Systems.CalculatedComponents;
using MAS.Services.ECS;
using MAS.Services.Game;

namespace MAS.Game.Core
{
    public class ServicesBootstrapper : IServicesBootstrapper
    {
        public void Bootstrap(IServiceRegistrar registrar)
        {
            registrar.Register<IGameEngine, GameEngine>();
            registrar.Register<IDeckCreator, DeckCreator>();

            registrar.Register<ISystem, CardDetailsProviderSystem>();
            registrar.Register<ISystem, CardPreparationSystem>();

            registrar.Register<ISystem, PowerSystem>();
            registrar.Register<ISystem, ToughnessSystem>();

            registrar.Register<ISystem, ZombiesGainsPlusOnePlusOneCounterSystem>();
        }
    }
}