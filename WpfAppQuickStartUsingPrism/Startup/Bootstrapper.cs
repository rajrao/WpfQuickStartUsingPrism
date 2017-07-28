using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppQuickStartUsingPrism.Modules;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Unity;

namespace WpfAppQuickStartUsingPrism.Startup
{
	public class Bootstrapper : UnityBootstrapper
	{
		public Bootstrapper()
		{
			ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
			{
				var viewName = viewType.FullName;
				var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;

				const string view = "View";
				if (viewName.EndsWith(view))
				{
					viewName = viewName.Substring(0, viewName.Length - view.Length);
				}
				var viewModelName = String.Format(CultureInfo.InvariantCulture, "{0}ViewModel, {1}", viewName.Replace(".Views.", ".ViewModels."), viewAssemblyName);
				var viewModelType = Type.GetType(viewModelName);
				return viewModelType;
			});

			ViewModelLocationProvider.SetDefaultViewModelFactory((type) =>
			{
				return Container.Resolve(type);
			});

		}
		protected override DependencyObject CreateShell()
		{
			return Container.Resolve<MainWindow>();
		}
		protected override void InitializeModules()
		{
			base.InitializeModules();
			Application.Current.MainWindow = (MainWindow)Shell;
			Application.Current.MainWindow.Show();
		}
		protected override void ConfigureModuleCatalog()
		{
			base.ConfigureModuleCatalog();
			ModuleCatalog moduleCatalog = (ModuleCatalog)ModuleCatalog;
			moduleCatalog.AddModule(typeof(MainModule));
		}

		protected override void ConfigureContainer()
		{
			var containerConfiguration = new ContainerConfiguration();
			containerConfiguration.Configure(this);

			base.ConfigureContainer();
		}
	}
}
