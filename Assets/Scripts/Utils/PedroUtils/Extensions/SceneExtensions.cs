// maded by Pedro M Marangon
using System;
using UnityEngine.SceneManagement;

namespace PedroUtils
{
	public static class SceneExtensions
	{
		public static bool ContainsInName(this Scene scene, params string[] names)
		{
			for (int i = 0; i < names.Length; i++)
			{
				var contains = scene.name.Contains(names[i], StringComparison.InvariantCultureIgnoreCase);
				if (contains) return true;
			}

			return false;
		}
	}

}