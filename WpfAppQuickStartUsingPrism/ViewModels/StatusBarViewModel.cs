using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppQuickStartUsingPrism.Common;
using WpfAppQuickStartUsingPrism.Events;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace WpfAppQuickStartUsingPrism.ViewModels
{
	public class StatusBarViewModel : ViewModelBase
	{
		public ObservableCollection<LogMessage> LogMessages { get; }
		public StatusBarViewModel(IUnityContainer container, IEventAggregator eventAggregator) : base(container, eventAggregator)
		{
			LogMessages = new ObservableCollection<LogMessage>();
			EventAggregator.GetEvent<LogMessageRaised>().Subscribe(LogMessageReceived, ThreadOption.UIThread);
			EventAggregator.GetEvent<ClearLogMessages>().Subscribe(ClearLogMessageReceived, ThreadOption.UIThread);
		}

		private void ClearLogMessageReceived()
		{
			LogMessages.Clear();
		}

		private void LogMessageReceived(LogMessage logMessage)
		{
			LogMessages.Insert(0, logMessage);
		}
	}
}
