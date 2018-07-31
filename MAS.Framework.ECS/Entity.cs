using System;
using System.Collections.Generic;

using JetBrains.Annotations;

using MAS.Services.ECS;
using MAS.Services.Logging;

namespace MAS.Framework.ECS
{
    internal class Entity : IEntity
    {
        private readonly int _Id;

        [NotNull]
        private readonly EntityContainer _Container;

        [NotNull]
        private readonly ILogger _Logger;

        [NotNull]
        private readonly Dictionary<Type, object> _Components = new Dictionary<Type, object>();

        public Entity([NotNull] EntityContainer container, int id, [NotNull] ILogger logger)
        {
            _Id = id;
            _Container = container ?? throw new ArgumentNullException(nameof(container));
            _Logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _Logger.Debug($"{this} created");
        }

        public bool HasComponent<T>()
            where T: class
            => _Components.ContainsKey(typeof(T));

        public bool TryGetComponent<T>(out T component)
            where T: class
        {
            if (_Components.TryGetValue(typeof(T), out object temp))
            {
                component = (T)temp;
                return true;
            }

            component = null;
            return false;
        }


        public void SetComponent<T>(T component)
            where T: class
        {
            var componentAlreadyPresent = _Components.ContainsKey(typeof(T));

            _Components[typeof(T)] = component ?? throw new ArgumentNullException(nameof(component));

            _Logger.Debug(componentAlreadyPresent ? $"{this} replaced {component}" : $"{this} gained {component}");

            _Container.ComponentSet(this, component);
        }

        public void RemoveComponent<T>()
            where T: class
        {
            if (_Components.TryGetValue(typeof(T), out object component))
            {
                _Components.Remove(typeof(T));
                _Logger.Debug($"{this} lost {component}");
                _Container.ComponentRemoved(this, component);
            }
        }

        public override string ToString() => $"Entity #{_Id}";
    }
}