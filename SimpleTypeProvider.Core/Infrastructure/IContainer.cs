using System;
using System.Reflection;
using System.Collections.Generic;

namespace SimpleTypeProvider.Core
{
	public interface IContainer
	{
		T GetInstance<T>();
        object GetInstance(Type t);
        bool HasInstance<T>();
        bool HasInstance(Type t);
	}
	
}
