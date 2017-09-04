using ProjectSpace.Services;
using impl=ProjectSpace.Services.Implementations;
using System;
using SimpleInjector;

namespace ProjectSpace
{
    public static class AppContainer
    {
        internal static SimpleInjector.Container Current;
        static AppContainer()
        {
            Current = new SimpleInjector.Container();
            Current.Options.DefaultScopedLifestyle = new SimpleInjector.Lifestyles.ThreadScopedLifestyle();
            
        }

        public static void Setup()
        {
            Current.Register<IEmployeeService, impl.EmployeeService>(Lifestyle.Scoped);
        }

        public static void Setup(Action<Container> action)
        {
            Setup();
            action(Current);
        }

        public static void RegisterTypes(Action<Container> action)
        {
            action(Current);
        }
    }
}
