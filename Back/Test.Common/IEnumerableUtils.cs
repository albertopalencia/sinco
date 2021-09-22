using System.Collections.Generic;

namespace Test.Common
{
	public static class EnumerableUtils
	{
		public static string JoinStrings(this IEnumerable<string> strings, string separator)
		{
			return string.Join(separator, strings);
		}
	}
}