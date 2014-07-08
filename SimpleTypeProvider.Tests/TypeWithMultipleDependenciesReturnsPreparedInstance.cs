using NUnit.Framework;
using System;

namespace SimpleTypeProvider.Core.Tests
{
    [TestFixture()]
    public class TypeWithMultipleDependenciesReturnsPreparedInstance
    {
        private IComplexType _result;

        [TestFixtureSetUp]
        public void SetUp() 
        {
            SimpleTypeProvider.Initialize(cfg =>
                {
                    cfg.Register(typeof(ICalculateNumbers), typeof(NumberCalculator));
                    cfg.Register(typeof(IComplexType), typeof(EvenMoreComplexType));
                    cfg.Register(typeof(IProvideValues), typeof(NumberProvider));
                });

            _result = SimpleTypeProvider.Container.GetInstance<IComplexType>();
        }

        [Test]
        public void CreatesValidInstanceOfComplexType()
        {
            Assert.IsNotNull(_result);
        }

        [Test]
        public void CanUseInstanceOfClassWithDependency()
        {
            Assert.AreEqual(5, _result.ComplexMethod(1));
        }
    }
}

