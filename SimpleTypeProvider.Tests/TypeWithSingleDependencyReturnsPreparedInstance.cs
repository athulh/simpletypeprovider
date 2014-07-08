using NUnit.Framework;
using System;
using SimpleTypeProvider.Core;

namespace SimpleTypeProvider.Core.Tests
{
    [TestFixture]
    public class TypeWithSingleDependencyReturnsPreparedInstance
    {   
        private IComplexType _result;

        [TestFixtureSetUp]
        public void SetUp() 
        {
            SimpleTypeProvider.Initialize(cfg =>
                {
                    cfg.Register(typeof(ICalculateNumbers), typeof(NumberCalculator));
                    cfg.Register(typeof(IComplexType), typeof(ComplexType));
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
            Assert.AreEqual(2, _result.ComplexMethod(1));
        }
    }
}

