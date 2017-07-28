using System.Collections.Generic;
using Prism.Events;
using WpfAppQuickStartUsingPrism.Models;

namespace WpfAppQuickStartUsingPrism.Events
{
	class RowsLoadedEvent : PubSubEvent<List<RowDetailModel>>
	{
	}
}