using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppQuickStartUsingPrism.Views;
using Prism.Regions;

namespace WpfAppQuickStartUsingPrism.Modules
{
	public static class RegionNames
	{
		public const string TopBar = "TopBar";
		public const string MainRegion = "MainRegion";
		public const string StatusBar = "StatusBar";
	}
	public class MainModule : IModule
	{
		private readonly IRegionViewRegistry _regionViewRegistry = null;

		public MainModule(IRegionViewRegistry regionViewRegistry)
		{
			_regionViewRegistry = regionViewRegistry;
		}

		public void Initialize()
		{
			_regionViewRegistry.RegisterViewWithRegion(RegionNames.TopBar, typeof(TopBarView));
			_regionViewRegistry.RegisterViewWithRegion(RegionNames.MainRegion, typeof(MainRegionView));
			_regionViewRegistry.RegisterViewWithRegion(RegionNames.StatusBar, typeof(StatusBarView));
		}
	}
}
