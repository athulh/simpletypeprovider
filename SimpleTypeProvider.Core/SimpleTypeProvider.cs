using System;
using System.Reflection;
using System.Collections.Generic;

namespace SimpleTypeProvider.Core
{
	public class SimpleTypeProvider : IContext, IContainer
	{
		public static IContainer Container { get ; private set; }
		private IDictionary<Type,Type> _registeredTypes;
        private IDictionary<Type, Func<IContainer, dynamic>> _registeredFactoryMethods;

        protected SimpleTypeProvider() 
        { 
            _registeredTypes = new Dictionary<Type,Type>();
            _registeredFactoryMethods = new Dictionary<Type, Func<IContainer, dynamic>>();
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
                return (T)Activator.CreateInstance(_registeredTypes[typeof(T)]);
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
	}
}

