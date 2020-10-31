using Autofac;

namespace LoggingProfiler.Implementations
{
    internal class IoCContainerManager
    {
        protected IContainer _container;

        public IoCContainerManager()
        {
            RegisterTypes();
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        protected virtual void RegisterTypes()
        {
            var containerBuiler = new ContainerBuilder();

            containerBuiler.RegisterType<Logger>().AsImplementedInterfaces().SingleInstance();

            _container = containerBuiler.Build();
        }
    }
}