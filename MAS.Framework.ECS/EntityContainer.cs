using System;
using System.Collections.Generic;

using JetBrains.Annotations;

using MAS.Services.ECS;
using MAS.Services.Logging;

namespace MAS.Framework.ECS
{
    internal class EntityContainer : IEntityContainer
    {
        [NotNull]
        private readonly ILogger _Logger;
        private int _NextId;

        [NotNull]
        private readonly Dictionary<Type, List<ISystem>> _SystemsByComponentsTheyReactTo =
            new Dictionary<Type, List<ISystem>>();

        public EntityContainer([NotNull, ItemNotNull] IEnumerable<ISystem> systems, [NotNull] ILogger logger)
        {
            _Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            foreach (ISystem system in systems)
            {
                foreach (Type type in system.ReactsToComponentTypes())
                {
                    if (!_SystemsByComponentsTheyReactTo.TryGetValue(type, out List<ISystem> systemsThatReactsToType))
                    {
                        systemsThatReactsToType = new List<ISystem>();
                        _SystemsByComponentsTheyReactTo[type] = systemsThatReactsToType;
                    }

                    systemsThatReactsToType.Add(system);
                }
            }
        }

        public IEntity CreateEntity() => new Entity(this, ++_NextId, _Logger);

        public void ComponentSet<T>([NotNull] Entity entity, [NotNull] T component)
        {
            if (!_SystemsByComponentsTheyReactTo.TryGetValue(typeof(T), out List<ISystem> systems))
                return;

            foreach (ISystem system in systems)
                system.ComponentSet(entity, component);
        }

        public void ComponentRemoved<T>([NotNull] Entity entity, [NotNull] T component)
        {
            if (!_SystemsByComponentsTheyReactTo.TryGetValue(typeof(T), out List<ISystem> systems))
                return;

            foreach (ISystem system in systems)
                system.ComponentRemoved(entity, component);
        }
    }
}