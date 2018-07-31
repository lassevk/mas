using System;

using JetBrains.Annotations;

namespace MAS.Services.ECS
{
    public static class EntityExtensions
    {
        [NotNull]
        public static T GetComponent<T>([NotNull] this IEntity entity)
            where T : class
        {
            if (!entity.TryGetComponent(out T component))
                throw new InvalidOperationException($"Unable to get component of type '{typeof(T).FullName}' from entity");

            return component;
        }

        [CanBeNull]
        public static T GetComponentOrDefault<T>([NotNull] this IEntity entity)
            where T : class
        {
            entity.TryGetComponent(out T component);
            return component;
        }
    }
}
