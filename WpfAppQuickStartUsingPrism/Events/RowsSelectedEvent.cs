using System.Collections.Generic;
using Prism.Events;
using WpfAppQuickStartUsingPrism.Models;

namespace WpfAppQuickStartUsingPrism.Events
{
	class RowsSelectedEvent : PubSubEvent<List<RowDetailModel>>
	{

	}
}