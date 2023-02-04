// maded by Pedro M Marangon
using UnityEngine;

namespace PedroUtils
{
	public static class TransformExtensions
	{
		public static void Clear(this Transform transform)
		{
			for (int i = transform.childCount - 1; i >= 0; i--) transform.GetChild(i).Suicide();
		}
	}

}