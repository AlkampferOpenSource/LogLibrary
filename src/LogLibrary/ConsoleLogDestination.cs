using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLibrary
{
	public class ConsoleLogDestination : ILogDestination
	{
		public void AddLog(LogMessage message)
		{
			Console.WriteLine(message.RenderedMessage);
		}
	}
}
