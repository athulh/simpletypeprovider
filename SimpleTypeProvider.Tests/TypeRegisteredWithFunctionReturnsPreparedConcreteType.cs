using System;
using NUnit.Framework;

namespace SimpleTypeProvider.Core.Tests
{
    [TestFixture]
    public class TypeRegisteredWithFunctionReturnsPreparedConcreteType
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            SimpleTypeProvider.Initialize(cfg => { 
                cfg.Register(typeof(ISimpleType), (ctx) => {
                    return new SimpleTypeWithInitializer("Hello Simple Type"); 
                });
            });
        }

        [Test]
        public void RequestISimpleTypeGetInitializedType()
        {
            ISimpleType t = SimpleTypeProvider.Container.GetInstance<ISimpleType>();

            Assert.IsNotNull(t);
            Assert.IsInstanceOfType(typeof(SimpleTypeWithInitializer), t);

            Assert.AreEqual("Hello Simple Type", ((SimpleTypeWithInitializer)t).Value);
        }
    }
}

