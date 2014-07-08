using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace SimpleTypeProvider.Core
{
    public class DefaultTypeResolver : IResolveTypes
    {
        public T ResolveInstance<T>(Type of, IContainer container)
        {
            var info = of.GetTypeInfo();

            foreach (var constructor in info.DeclaredConstructors.ToList())
            {
                if (constructor.GetParameters().Count() == 0)
                    continue;

                var canFillAllParameters = constructor.GetParameters().All(p => container.HasInstance(p.ParameterType));

                if (!canFillAllParameters)
                    continue;

                var parameters = (from p in constructor.GetParameters()
                                              let r = container.GetInstance(p.ParameterType)
                                              select r).ToArray();
                    
                return (T)constructor.Invoke(parameters);
            }

            return (T)Activator.CreateInstance(of);
        }
    }
}

