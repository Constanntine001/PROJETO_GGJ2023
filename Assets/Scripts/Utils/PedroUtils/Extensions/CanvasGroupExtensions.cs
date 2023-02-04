// maded by Pedro M Marangon
using UnityEngine;

namespace PedroUtils
{
	public static class CanvasGroupExtensions
	{
		public static void SetValues(this CanvasGroup group, float alpha, bool combinedValue)
		{
			group.alpha = alpha;
			group.interactable = group.blocksRaycasts = combinedValue;
		}
	}

}