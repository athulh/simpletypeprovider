using System;

namespace SimpleTypeProvider.Core.Tests
{
    public class SimpleTypeWithInitializer : ISimpleType
    {
        public string Value { get; private set;}

        public SimpleTypeWithInitializer(string value)
        {
            Value = value;
        }

        #region ISimpleType implementation

        public string DoSomething()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

