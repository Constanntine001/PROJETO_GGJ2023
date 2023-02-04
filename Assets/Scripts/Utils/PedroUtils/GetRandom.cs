// maded by Pedro M Marangon
using System.Collections.Generic;
using UnityEngine;

namespace PedroUtils
{
	public class GetRandom
	{
		public static TObject Element<TObject>(List<TObject> obj)
		{
			if (obj.Count <= 0) return default(TObject);
			if (obj.Count == 1) return obj[0];
			int position = Random.Range(0, obj.Count);
			return obj[position];
		}

		public static float ValueFromVector2(Vector2 range) => Random.Range(range.x, range.y);

		public static bool Boolean => Random.value > 0.5f;
	}
}