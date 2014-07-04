using System;
using NUnit.Framework;

namespace SimpleTypeProvider.Core.Tests
{
    [TestFixture]
    public class TypeRegisteredThroughRegistryWithMethodReturnsConcreteType
    {
        public class SampleRegistry : SimpleTypeRegistry
        {
            public SampleRegistry(IContext context) 
                : base(context)
            {
                For<ISimpleType>().Use(ctx => { 
                    return new SimpleTypeWithInitializer("Hello World, again");
                });
            }
        }

        [TestFixtureSetUp]
        public void SetUp()
        {
            SimpleTypeProvider.Initialize(cfg => { 
                cfg.UseRegistry(typeof(SampleRegistry));
            });
        }

        [Test]
        public void RequestISimpleTypeGetInitializedType()
        {
            ISimpleType t = SimpleTypeProvider.Container.GetInstance<ISimpleType>();

            Assert.IsNotNull(t);
            Assert.IsInstanceOfType(typeof(SimpleTypeWithInitializer), t);

            Assert.AreEqual("Hello World, again", ((SimpleTypeWithInitializer)t).Value);
        }
    }
}

