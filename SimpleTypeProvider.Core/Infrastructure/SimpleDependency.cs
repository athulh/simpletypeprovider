using System;
using System.Reflection;
using System.Collections.Generic;

namespace SimpleTypeProvider.Core
{
	public class SimpleDependency : IDependency
	{
		private Type forType;
		private IContext context;

		public SimpleDependency(IContext context, Type forType)
		{
			this.context = context;
			this.forType = forType;
		}

		public IDependency Use<T>()
		{
			this.context.Register(forType, typeof(T));

			return this;
		}

        public IDependency Use<T>(Func<IContainer, T> cfg)
            where T : class
        {
            this.context.Register(forType, cfg);

            return this;
        }

		public IDependency Use(Type t)
		{
			this.context.Register(forType, t);

			return this;
		}
	}
	
}
