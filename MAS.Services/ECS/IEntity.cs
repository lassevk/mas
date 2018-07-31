using JetBrains.Annotations;

namespace MAS.Services.ECS
{
    public interface IEntity
    {
        bool HasComponent<T>()
            where T: class;

        [ContractAnnotation("=> false, component:null")]
        [ContractAnnotation("=> true, component:notnull")]
        bool TryGetComponent<T>([CanBeNull] out T component)
            where T: class;

        void SetComponent<T>([NotNull] T component)
            where T: class;

        void RemoveComponent<T>()
            where T: class;
    }
}