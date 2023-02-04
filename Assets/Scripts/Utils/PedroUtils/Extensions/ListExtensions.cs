// maded by Pedro M Marangon
using System.Collections.Generic;
using UnityEngine;

namespace PedroUtils
{
	public static class ListExtensions
	{
		public static void Print<T>(this List<T> list, string listName = "List")
		{
			string msg = $"{listName}: (";

			for (int i = 0; i < list.Count; i++)
			{
				msg += $"{list[i]}";
				if (i < list.Count - 1)
				{
					msg += "; ";
				}
			}

			msg += ")";

			Debug.Log(msg);
		}
	}

}