// maded by Pedro M Marangon
using System;
using System.Collections.Generic;
using System.Linq;

namespace PedroUtils
{
	public static class ArrayExtensions
	{
		public static T[] RemoveAll<T>(this T[] array, Predicate<T> match)
		{
			List<T> list = array.ToList();
			list.RemoveAll(match);
			return list.ToArray();
		}
	}
}