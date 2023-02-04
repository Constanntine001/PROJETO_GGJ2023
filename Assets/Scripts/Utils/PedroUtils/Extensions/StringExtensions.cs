// maded by Pedro M Marangon
using UnityEngine;

namespace PedroUtils
{
	public static class StringExtensions
	{
		public static string Color(this string myStr, string color) => $"<color={color}>{myStr}</color>";
		
		public static string Color(this string myStr, Color color) => myStr.Color($"#{ColorUtility.ToHtmlStringRGBA(color)}");
		
		public static string ToSize(this string myStr, int size) => $"<size={size}>{myStr}</size>";
		
		public static string Bold(this string myStr) => $"<b>{myStr}</b>";
		
		public static bool ContainsValues(this string myStr, params string[] values)
		{
			for (int i = 0; i < values.Length; i++)
			{
				if (myStr.Contains(values[i])) return true;
			}
			return false;
		}
	}

}