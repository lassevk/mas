using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using JetBrains.Annotations;

using NUnit.Framework;

// ReSharper disable PossibleNullReferenceException
// ReSharper disable AssignNullToNotNullAttribute
// ReSharper disable MemberCanBePrivate.Global

namespace MAS.Tests.Framework
{
    public abstract class ApiTestsBase<T>
    {
        public static IEnumerable<Type> PublicTypesInAssembly()
            => typeof(T).Assembly.GetTypes().Where(type => type.IsPublic);

        public static IEnumerable<Type> NonPublicTypesInAssembly()
            => typeof(T).Assembly.GetTypes().Where(type => !type.IsPublic);

        public static IEnumerable<PropertyInfo> PropertiesOfPublicTypes()
            => PublicTypesInAssembly().SelectMany(type => type.GetProperties());

        public static IEnumerable<PropertyInfo> ReferencePropertiesOfPublicTypes()
            => PropertiesOfPublicTypes().Where(property => property.PropertyType.IsClass || property.PropertyType.IsInterface);

        public static IEnumerable<PropertyInfo> CollectionPropertiesOfPublicTypes()
            => ReferencePropertiesOfPublicTypes().Where(property => IsCollectionType(property.PropertyType));

        public static IEnumerable<MethodInfo> PublicMethodsOfPublicTypes()
            => PublicTypesInAssembly().SelectMany(type => type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static));

        public static IEnumerable<MethodInfo> PublicMethodsWithReferenceReturnTypes()
            => PublicMethodsOfPublicTypes()
               .Where(method => method.ReturnType != typeof(void) && method.ReturnType.IsClass || method.ReturnType.IsInterface);

        public static IEnumerable<MethodInfo> PublicMethodsWithCollectionReturnTypes()
            => PublicMethodsWithReferenceReturnTypes().Where(method => IsCollectionType(method.ReturnType));

        public static IEnumerable<ParameterInfo> ReferenceParametersOfPublicMethodsOfPublicTypes()
            => PublicMethodsOfPublicTypes()
               .SelectMany(method => method.GetParameters().Where(parmt => parmt.ParameterType.IsClass || parmt.ParameterType.IsInterface));

        public static IEnumerable<ParameterInfo> CollectionParametersOfPublicMethodsOfPublicTypes()
            => ReferenceParametersOfPublicMethodsOfPublicTypes().Where(parmt => IsCollectionType(parmt.ParameterType));

        private static bool IsCollectionType(Type type)
        {
            if (type.IsArray)
                return true;

            if (type.IsGenericType)
            {
                Type genericType = type.GetGenericTypeDefinition();

                switch (genericType)
                {
                    case Type t1 when t1 == typeof(List<>):
                    case Type t2 when t2 == typeof(IList<>):
                    case Type t3 when t3 == typeof(ICollection<>):
                    case Type t4 when t4 == typeof(HashSet<>):
                        return true;
                }
            }

            return false;
        }

        [Test]
        [TestCaseSource(nameof(PublicTypesInAssembly))]
        public void PublicType_PublicApiAttribute_Exists(Type type)
        {
            var hasPublicApiAttribute = type.IsDefined(typeof(PublicAPIAttribute), false);

            Assert.That(hasPublicApiAttribute, Is.True, $"Public type {type.FullName} should have [PublicAPI]");
        }

        [Test]
        [TestCaseSource(nameof(NonPublicTypesInAssembly))]
        public void NonPublicType_PublicApiAttribute_DoesNotExist(Type type)
        {
            var hasPublicApiAttribute = type.IsDefined(typeof(PublicAPIAttribute), false);

            Assert.That(hasPublicApiAttribute, Is.False, $"Non-public type {type.FullName} should not have [PublicAPI]");
        }

        [Test]
        [TestCaseSource(nameof(ReferencePropertiesOfPublicTypes))]
        public void ReferenceProperty_OfPublicType_HasNotNullOrCanBeNullAttribute(PropertyInfo property)
        {
            var hasNotNullAttribute = property.IsDefined(typeof(NotNullAttribute), true);
            var hasCanBeNullAttribute = property.IsDefined(typeof(CanBeNullAttribute), true);

            Assert.That(hasNotNullAttribute || hasCanBeNullAttribute, Is.True, $"Property {property.Name} of {property.DeclaringType.FullName} should have [NotNull] or [CanBeNull]");
        }

        [Test]
        [TestCaseSource(nameof(PublicMethodsWithReferenceReturnTypes))]
        public void ReferenceReturnType_OfPublicMethodOfOfPublicType_HasNotNullOrCanBeNullAttribute(MethodInfo method)
        {
            var hasNotNullAttribute = method.IsDefined(typeof(NotNullAttribute), true);
            var hasCanBeNullAttribute = method.IsDefined(typeof(CanBeNullAttribute), true);

            Assert.That(hasNotNullAttribute || hasCanBeNullAttribute, Is.True, $"Method {method.Name} of {method.DeclaringType.FullName} should have [NotNull] or [CanBeNull]");
        }

        [Test]
        [TestCaseSource(nameof(ReferenceParametersOfPublicMethodsOfPublicTypes))]
        public void ReferenceParameter_OfPublicMethodOfPublicType_HasNotNullOrCanBeNullAttribute(ParameterInfo parameter)
        {
            var hasNotNullAttribute = parameter.IsDefined(typeof(NotNullAttribute), true);
            var hasCanBeNullAttribute = parameter.IsDefined(typeof(CanBeNullAttribute), true);

            Assert.That(hasNotNullAttribute || hasCanBeNullAttribute, Is.True, $"Parameter {parameter.Name} of method {parameter.Member.Name} of {parameter.Member.DeclaringType.FullName} should have [NotNull] or [CanBeNull]");
        }

        [Test]
        [TestCaseSource(nameof(CollectionPropertiesOfPublicTypes))]
        public void CollectionProperty_OfPublicType_HasItemNotNullOrItemCanBeNullAttribute(PropertyInfo property)
        {
            var hasItemNotNullAttribute = property.IsDefined(typeof(ItemNotNullAttribute), true);
            var hasItemCanBeNullAttribute = property.IsDefined(typeof(ItemCanBeNullAttribute), true);

            Assert.That(hasItemNotNullAttribute || hasItemCanBeNullAttribute, Is.True, $"Property {property.Name} of {property.DeclaringType.FullName} should have [ItemNotNull] or [ItemCanBeNull]");
        }

        [Test]
        [TestCaseSource(nameof(PublicMethodsWithCollectionReturnTypes))]
        public void CollectionReturnType_OfPublicMethodOfOfPublicType_HasNotNullOrCanBeNullAttribute(MethodInfo method)
        {
            var hasItemNotNullAttribute = method.IsDefined(typeof(ItemNotNullAttribute), true);
            var hasItemCanBeNullAttribute = method.IsDefined(typeof(ItemCanBeNullAttribute), true);

            Assert.That(hasItemNotNullAttribute || hasItemCanBeNullAttribute, Is.True, $"Method {method.Name} of {method.DeclaringType.FullName} should have [ItemNotNull] or [ItemCanBeNull]");
        }
 
        [Test]
        [TestCaseSource(nameof(CollectionParametersOfPublicMethodsOfPublicTypes))]
        public void CollectionParameter_OfPublicMethodOfPublicType_HasNotNullOrCanBeNullAttribute(ParameterInfo parameter)
        {
            var hasItemNotNullAttribute = parameter.IsDefined(typeof(ItemNotNullAttribute), true);
            var hasItemCanBeNullAttribute = parameter.IsDefined(typeof(ItemCanBeNullAttribute), true);

            Assert.That(hasItemNotNullAttribute || hasItemCanBeNullAttribute, Is.True, $"Parameter {parameter.Name} of method {parameter.Member.Name} of {parameter.Member.DeclaringType.FullName} should have [ItemNotNull] or [ItemCanBeNull]");
        }
    }
}