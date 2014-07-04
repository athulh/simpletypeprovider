using System;
using System.Reflection;
using System.Collections.Generic;

namespace SimpleTypeProvider.Core
{
	public interface IDependency
	{
		IDependency Use<T>();
		IDependency Use(Type t);
        IDependency Use<T>(Func<IContainer, T> cfg) where T : class;
	}
	
}
