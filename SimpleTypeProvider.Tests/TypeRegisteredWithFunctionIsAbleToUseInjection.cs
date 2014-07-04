using System;
using NUnit.Framework;

namespace SimpleTypeProvider.Core.Tests
{
    [TestFixture]
    public class TypeRegisteredWithFunctionIsAbleToUseInjection
    {       
        [TestFixtureSetUp]
        public void SetUp()
        {
            SimpleTypeProvider.Initialize(cfg =>
                { 
                    cfg.Register(typeof(IInjectSomeValue), typeof(InjectSomeValue));
                    cfg.Register(typeof(ISimpleType), (ctx) => { 
                        return new SimpleTypeWithInitializer(ctx.GetInstance<IInjectSomeValue>().GetValue());
                    });
                });
        }

        [Test]
        public void RequestISimpleTypeGetInitializedTypeWithInjectedValue()
        {
            ISimpleType t = SimpleTypeProvider.Container.GetInstance<ISimpleType>();

            Assert.IsNotNull(t);
            Assert.IsInstanceOfType(typeof(SimpleTypeWithInitializer), t);
            Assert.AreEqual("Hello Cruel World", (t as SimpleTypeWithInitializer).Value);
        }
    }

    public interface IInjectSomeValue
    {
        string GetValue();
    }

    public class InjectSomeValue : IInjectSomeValue
    {
        public string GetValue()
        {
            return "Hello Cruel World";
        }
    }

}

