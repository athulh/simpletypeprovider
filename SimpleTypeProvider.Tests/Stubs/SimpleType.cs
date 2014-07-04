using NUnit.Framework;
using System;

namespace SimpleTypeProvider.Core.Tests
{
    public class SimpleType : ISimpleType
    {
        public string DoSomething() 
        { 
            return "Hello World";
        }
    }
}
