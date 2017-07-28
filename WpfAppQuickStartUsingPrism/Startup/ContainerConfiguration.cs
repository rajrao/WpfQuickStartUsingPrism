using Prism.Unity;
using Microsoft.Practices.Unity;

namespace WpfAppQuickStartUsingPrism.Startup
{
	public class ContainerConfiguration
	{
		public void Configure(UnityBootstrapper bootstrapper)
		{
			//UnityContainerExtensions.RegisterType<Interface, Type>(bootstrapper.Container, new InjectionConstructor());
			//UnityContainerExtensions.RegisterType<IFactory<Interface>, FactoryType>(bootstrapper.Container);
			//UnityContainerExtensions.RegisterType<Interface, Type>(bootstrapper.Container, new ContainerControlledLifetimeManager());
		
			var mapper = MapperConfiguration.Configure();
			bootstrapper.Container.RegisterInstance(mapper);
		}


	}
}