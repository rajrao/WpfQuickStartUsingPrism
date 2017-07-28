using AutoMapper;
using WpfAppQuickStartUsingPrism.Common;
using WpfAppQuickStartUsingPrism.Events;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Mvvm;

namespace WpfAppQuickStartUsingPrism.ViewModels
{
	public abstract class ViewModelBase : BindableBase
	{
		private ILogger _logMessageRaised;
		protected ViewModelBase(IUnityContainer container, IEventAggregator eventAggregator)
		{
			Container = container;
			EventAggregator = eventAggregator;
			_logMessageRaised = EventAggregator.GetEvent<LogMessageRaised>();
		}
		protected IUnityContainer Container { get; }
		protected IEventAggregator EventAggregator { get; }

		public ILogger Logger
		{
			get { return _logMessageRaised; }
			set { _logMessageRaised = value; }
		}

		[Dependency]
		protected IMapper Mapper { get; set; }
	}
}