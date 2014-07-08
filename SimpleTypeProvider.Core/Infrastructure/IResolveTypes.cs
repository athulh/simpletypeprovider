using System;

namespace SimpleTypeProvider.Core
{
    public interface IResolveTypes
    {
        T ResolveInstance<T>(Type of, IContainer container);
    }
}

