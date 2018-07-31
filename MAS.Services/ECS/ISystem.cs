using System;
using System.Collections.Generic;

using JetBrains.Annotations;

namespace MAS.Services.ECS
{
    public interface ISystem
    {
        [NotNull, ItemNotNull]
        IEnumerable<Type> ReactsToComponentTypes();

        void ComponentSet([NotNull] IEntity entity, [NotNull] object component);
        void ComponentRemoved([NotNull] IEntity entity, [NotNull] object component);
    }
}