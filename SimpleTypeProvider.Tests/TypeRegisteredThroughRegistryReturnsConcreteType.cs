using System;
using NUnit.Framework;

namespace SimpleTypeProvider.Core.Tests
{
    [TestFixture]
    public class TypeRegisteredThroughRegistryReturnsConcreteType
    {
        public class SampleRegistry : SimpleTypeRegistry
        {
            public SampleRegistry(IContext context) 
                : base(context) 
            {
                For<ISimpleType>().Use<SimpleType>();
            }
        }

        [TestFixtureSetUp]
        public void SetUp()
        {
            SimpleTypeProvider.Initialize(cfg =>
                {
                    cfg.UseRegistry(typeof(SampleRegistry));
                });
        }

        [Test]
        public void RequestISimpleTypeGetSimpleType()
        {
            ISimpleType t = SimpleTypeProvider.Container.GetInstance<ISimpleType>();

            Assert.IsNotNull(t);
            Assert.IsInstanceOfType(typeof(SimpleType), t);
        }
    }      
}

