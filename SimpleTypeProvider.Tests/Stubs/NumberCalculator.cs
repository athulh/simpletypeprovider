using System;

namespace SimpleTypeProvider.Core.Tests
{

    public class NumberCalculator : ICalculateNumbers
    {
        public int Add(int val1, int val2)
        {
            return val1 + val2;
        }
    }
}
