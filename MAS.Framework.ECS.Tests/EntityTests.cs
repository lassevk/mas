using System;

using MAS.Services.ECS;

using NUnit.Framework;

// ReSharper disable AssignNullToNotNullAttribute
// ReSharper disable PossibleNullReferenceException

namespace MAS.Framework.ECS.Tests
{
    [TestFixture]
    public class EntityTests
    {
        private EntityContainer _Container;
        
        private IEntity _Entity;

        [SetUp]
        public void SetUp()
        {
            _Container = new EntityContainer();
            
            _Entity = _Container.CreateEntity();
        }

        [Test]
        public void SetComponent_NullComponent_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _Entity.SetComponent<string>(null));
        }

        [Test]
        public void HasComponent_ComponentMissing_ReturnsFalse()
        {
            var output = _Entity.HasComponent<string>();

            Assert.That(output, Is.False);
        }

        [Test]
        public void HasComponent_ComponentPresent_ReturnsTrue()
        {
            _Entity.SetComponent("Test");
            
            var output = _Entity.HasComponent<string>();

            Assert.That(output, Is.True);
        }

        [Test]
        public void HasComponent_AfterComponentHasBeenRemoved_ReturnsFalse()
        {
            _Entity.SetComponent("Test");
            _Entity.RemoveComponent<string>();

            var output = _Entity.HasComponent<string>();

            Assert.That(output, Is.False);
        }


        [Test]
        public void TryGetComponent_ComponentMissing_ReturnsFalse()
        {
            var output = _Entity.TryGetComponent(out string _);

            Assert.That(output, Is.False);
        }

        [Test]
        public void TryGetComponent_ComponentPresent_ReturnsTrue()
        {
            _Entity.SetComponent("Test");

            var output = _Entity.TryGetComponent(out string _);

            Assert.That(output, Is.True);
        }

        [Test]
        public void TryGetComponent_ComponentPresent_AlsoReturnsThatComponent()
        {
            var input = "Test";
            _Entity.SetComponent(input);

            _Entity.TryGetComponent(out string component);

            Assert.That(component, Is.SameAs(input));
        }

        [Test]
        public void TryGetComponent_AfterComponentHasBeenRemoved_ReturnsFalse()
        {
            var input = "Test";
            _Entity.SetComponent(input);
            _Entity.RemoveComponent<string>();

            var output = _Entity.TryGetComponent(out string component);

            Assert.That(output, Is.False);
        }
    }
}