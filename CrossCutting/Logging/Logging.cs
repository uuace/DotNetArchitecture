using Solution.CrossCutting.Extensions;
using System;

namespace Solution.CrossCutting.Logging
{
	public class Logging : ILogging
	{
		public void Error(Exception exception)
		{
			if (exception == null) { return; }
			Console.WriteLine(exception.GetDetail());
		}

		public void Information(string message)
		{
			if (string.IsNullOrWhiteSpace(message)) { return; }
			Console.WriteLine(message);
		}
	}
}
