using System;
using System.Diagnostics;
using System.Text;

namespace Solution.CrossCutting.Utils
{
	public static class ExceptionExtensions
	{
		public static string GetDetail(this Exception exception)
		{
			var sb = new StringBuilder();

			sb.Append($"ERROR: { exception.Message }.");

			var stackFrame = new StackTrace(exception, true).GetFrame(0);

			if (stackFrame == null)
			{
				return sb.ToString();
			}

			sb.Append($"FILE: { stackFrame.GetMethod().DeclaringType }.");
			sb.Append($"LINE: { stackFrame.GetFileLineNumber() }.");

			return sb.ToString();
		}
	}
}
