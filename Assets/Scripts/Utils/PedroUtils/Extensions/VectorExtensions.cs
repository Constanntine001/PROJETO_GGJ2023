// maded by Pedro M Marangon
using UnityEngine;

namespace PedroUtils
{
	public static class VectorExtensions
	{
		//---------VECTOR3-----------//
		public static Vector3 With2Decimals(this Vector3 v) => new Vector3(v.x.With2Decimals(), v.y.With2Decimals(), v.z.With2Decimals());
		
		public static Vector3 With3Decimals(this Vector3 v) => new Vector3(v.x.With3Decimals(), v.y.With3Decimals(), v.z.With3Decimals());
		
		public static Vector3Int ToInt(this Vector3 v) => new Vector3Int((int)v.x, (int)v.y, (int)v.z);

		//---------VECTOR2-----------//
		public static Vector2Int RoundToInt(this Vector2 v)
		{
			int x = Mathf.RoundToInt(v.x);
			int y = Mathf.RoundToInt(v.y);
			return new Vector2Int(x, y);
		}
		
		public static Vector2 ToVector2(this Vector2Int v) => new Vector2(v.x, v.y);
	}

}