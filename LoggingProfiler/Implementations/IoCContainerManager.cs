using Autofac;
using LoggingProfiler.Models;

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

            var loggerConfiguration = new LoggerConfiguration();

            containerBuiler.RegisterType<Logger>()
                .WithParameter(new TypedParameter(typeof(LoggerConfiguration), loggerConfiguration))
                .AsImplementedInterfaces().SingleInstance();

            _container = containerBuiler.Build();
        }
    }
}