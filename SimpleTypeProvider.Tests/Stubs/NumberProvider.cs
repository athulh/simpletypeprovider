using System;

namespace SimpleTypeProvider.Core.Tests
{
    public class NumberProvider : IProvideValues    
    {
        public NumberProvider()
        {
        }

        public int GetNumber()
        {
            return 4;
        }
    }
}

