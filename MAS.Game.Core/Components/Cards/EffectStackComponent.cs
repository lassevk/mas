using System;
using System.Collections.Generic;
using System.Linq;

using JetBrains.Annotations;

using MAS.Services.ECS;

namespace MAS.Game.Core.Components.Cards
{
    public class EffectStackComponent
    {
        [NotNull]
        private readonly IEntity _Entity;

        [NotNull, ItemNotNull]
        private readonly List<object> _Effects = new List<object>();

        public EffectStackComponent([NotNull] IEntity entity)
        {
            _Entity = entity ?? throw new ArgumentNullException(nameof(entity));
        }

        public void AddEffect([NotNull] object effect)
        {
            _Effects.Add(effect);
            _Entity.SetComponent(this);
        }

        public void RemoveEffect(object effect)
        {
            if (_Effects.Remove(effect))
                _Entity.SetComponent(this);
        }

        public void ReplaceEffect(object effect, object newEffect)
        {
            for (var index = 0; index < _Effects.Count; index++)
                if (ReferenceEquals(_Effects[index], effect))
                {
                    _Effects[index] = newEffect;
                    _Entity.SetComponent(this);
                    return;
                }
        }

        public IEnumerable<object> GetEffects() => _Effects.ToList();

        public override string ToString() => $"EffectStack = {string.Join(", ", _Effects)}";
    }
}