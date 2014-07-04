using System;
using System.Reflection;
using System.Collections.Generic;

namespace SimpleTypeProvider.Core
{
	internal interface IRegisterTypes
	{
		IDependency For<T>();
		IDependency For (Type t);
	}
	
}
