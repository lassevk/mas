using System;
using System.Collections.Generic;

using JetBrains.Annotations;

using MAS.Services.ECS;

namespace MAS.Framework.ECS
{
    internal class Entity : IEntity
    {
        [NotNull]
        private readonly EntityContainer _Container;

        [NotNull]
        private readonly Dictionary<Type, object> _Components = new Dictionary<Type, object>();

        public Entity([NotNull] EntityContainer container)
        {
            _Container = container ?? throw new ArgumentNullException(nameof(container));
        }

        public bool HasComponent<T>()
            where T: class
            => _Components.ContainsKey(typeof(T));

        public bool TryGetComponent<T>([CanBeNull] out T component)
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


        public void SetComponent<T>([NotNull] T component)
            where T : class
        {
            _Components[typeof(T)] = component ?? throw new ArgumentNullException(nameof(component));
        }

        public void RemoveComponent<T>()
            where T : class
            => _Components.Remove(typeof(T));
    }
}