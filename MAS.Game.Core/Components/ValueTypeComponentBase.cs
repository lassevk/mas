namespace MAS.Game.Core.Components
{
    public abstract class ValueTypeComponentBase<T>
        where T: struct
    {
        protected ValueTypeComponentBase(T value)
        {
            Value = value;
        }

        public T Value { get; }

        public override string ToString() => $"{GetType().Name} = {Value}";
    }
}