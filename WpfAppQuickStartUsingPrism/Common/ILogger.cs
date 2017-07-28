namespace WpfAppQuickStartUsingPrism.Common
{
	public interface ILogger
	{
		void Publish(string logMessage, object source);
	}
}