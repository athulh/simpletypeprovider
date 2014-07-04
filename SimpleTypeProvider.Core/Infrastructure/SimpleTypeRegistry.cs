using System;
using System.Reflection;
using System.Collections.Generic;

namespace SimpleTypeProvider.Core
{
	public abstract class SimpleTypeRegistry : IRegisterTypes
	{
		public IContext Context { get; set; }

		protected SimpleTypeRegistry(IContext context) 
		{
			Context = context;
		}

		public IDependency For<T>()
		{
			return new SimpleDependency(Context, typeof(T));
		}

		public IDependency For(Type t)
		{
			return new SimpleDependency(Context, t);
		}
	}
}
