using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppQuickStartUsingPrism.Common
{
	public class LogMessage
	{
		public string Value { get; set; }
		public WeakReference Source { get; set; }
	}
}
