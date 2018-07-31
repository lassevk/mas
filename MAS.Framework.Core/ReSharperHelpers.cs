using System;
using System.Diagnostics;
using JetBrains.Annotations;

// ReSharper disable InconsistentNaming

namespace MAS.Framework.Core
{
    [PublicAPI]
    public static class ReSharperHelpers
    {
        [ContractAnnotation("instance:null => halt"), NotNull]
        public static T NotNull<T>([CanBeNull] this T instance)
            where T : class
            => instance ?? throw new ArgumentNullException(nameof(instance));

        [ContractAnnotation("expression:false => halt")]
        [Conditional("DEBUG")]
        public static void assume(bool expression)
        {
        }
    }
}