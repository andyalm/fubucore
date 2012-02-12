using System;
using FubuCore.Conversion;
using FubuCore.Util;

namespace FubuCore
{
    public interface IServiceLocator
    {
        T GetInstance<T>();
        object GetInstance(Type type);
    }

    public class InMemoryServiceLocator : IServiceLocator
    {
        private readonly Cache<Type, object> _services = new Cache<Type, object>();

        public InMemoryServiceLocator()
        {
            Add<IObjectConverter>(new ObjectConverter(this, new ConverterLibrary()));
        }

        public void Add<T>(T service)
        {
            _services[typeof(T)] = service;
        }

        public T GetInstance<T>()
        {
            return (T) _services[typeof (T)];
        }

        public object GetInstance(Type type)
        {
            return _services[type];
        }
    }
}