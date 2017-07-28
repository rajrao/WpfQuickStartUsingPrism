using System;
using WpfAppQuickStartUsingPrism.Common;
using Prism.Events;

namespace WpfAppQuickStartUsingPrism.Events
{
	public class LogMessageRaised : PubSubEvent<LogMessage>, ILogger
	{
		public void Publish(string logMessage, object source)
		{
			Publish(new LogMessage { Value = logMessage, Source = new WeakReference(source) });
		}
	}
}