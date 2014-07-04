using System;
using System.Reflection;
using System.Collections.Generic;

namespace SimpleTypeProvider.Core
{
	public interface IContext
	{
		void Register(Type from, Type to);
        void Register<T>(Type from, Func<IContainer,T> cfg) where T : class;
        void UseRegistry(Type registry);
	}
	
}
