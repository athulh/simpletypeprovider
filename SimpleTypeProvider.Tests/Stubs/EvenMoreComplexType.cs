using System;

namespace SimpleTypeProvider.Core.Tests
{
    public class EvenMoreComplexType : IComplexType
    {
        private ICalculateNumbers calc;
        private IProvideValues vals;

        public EvenMoreComplexType(ICalculateNumbers calc, IProvideValues vals)
        {
            this.vals = vals;
            this.calc = calc;
        }

        public int ComplexMethod(int val)
        {
            return calc.Add(val, vals.GetNumber());
        }
    }
}

