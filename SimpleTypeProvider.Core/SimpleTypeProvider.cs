using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace SimpleTypeProvider.Core
{
	public class SimpleTypeProvider : IContext, IContainer
	{
		public static IContainer Container { get ; private set; }

        public IResolveTypes TypeResolver { get; set; }

		private IDictionary<Type,Type> _registeredTypes;
        private IDictionary<Type, Func<IContainer, dynamic>> _registeredFactoryMethods;

        protected SimpleTypeProvider() 
        { 
            _registeredTypes = new Dictionary<Type,Type>();
            _registeredFactoryMethods = new Dictionary<Type, Func<IContainer, dynamic>>();
            TypeResolver = new DefaultTypeResolver();
        }

		public static IContainer Initialize(Action<IContext> cfg)
		{
			Container = new SimpleTypeProvider();

			cfg((IContext)Container);

			return Container;
		}

		public T GetInstance<T>() 
		{ 
            if (_registeredTypes.ContainsKey(typeof(T)))
            {
                return TypeResolver.ResolveInstance<T>(_registeredTypes[typeof(T)], this);
            }
            else
            {
                if (_registeredFactoryMethods.ContainsKey(typeof(T)))
                {
                    var result = _registeredFactoryMethods[typeof(T)].Invoke(this);
                   
                    return (T)result;
                }
            }

			return default(T);
		}

        public object GetInstance(Type t)
        {
            var getInstance = this.GetType().GetTypeInfo()
                        .GetDeclaredMethods("GetInstance")
                .SingleOrDefault(m => m.IsGenericMethod);

            var genericMethod = getInstance.MakeGenericMethod(t);
         
            return genericMethod.Invoke(this, null);
        }

        public bool HasInstance<T>()
        {
            return HasInstance(typeof(T));
        }

        public bool HasInstance(Type t)
        {
            return _registeredTypes.ContainsKey(t);
        }
			
		public void Register(Type from, Type to)
		{
			_registeredTypes.Add(from, to);
		}

        public void Register<T>(Type from, Func<IContainer, T> cfg)
            where T : class
        {
            _registeredFactoryMethods.Add(from, cfg);
        }

		public void UseRegistry(Type registryType) 
		{ 
			Activator.CreateInstance(registryType, this);
		}

        public void UseRegistry<TRegistry>()
            where TRegistry : SimpleTypeRegistry
        {
            Activator.CreateInstance(typeof(TRegistry), this);
        }
	}
}

