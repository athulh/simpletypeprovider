using System;

namespace SimpleTypeProvider.Core.Tests
{

    public class ComplexType : IComplexType
    {
        private readonly ICalculateNumbers numberCalculator;

        public ComplexType(ICalculateNumbers numberCalculator)
        {
            this.numberCalculator = numberCalculator;
        }

        public int ComplexMethod(int val)
        {
            return numberCalculator.Add(val, val);
        }
    }
    
}
