// maded by Pedro M Marangon
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PedroUtils
{
	public static class GizmoDrawer
	{
#if UNITY_EDITOR
		public static void Line(Color color, Vector3 start, Vector3 end, bool additiveEnd)
		{
			Gizmos.color = color;
			Gizmos.DrawLine(start, additiveEnd ? (start + end) : end);
		}
		
		public static void Sphere(Color color, Vector3 position, float radius, bool wireframe)
		{
			Gizmos.color = color;
			if (wireframe) Gizmos.DrawWireSphere(position, radius);
			else Gizmos.DrawSphere(position, radius);
		}

		public static void Capsule(Color color, Vector3 defaultPosition, Vector3 offset, float height, float width)
		{
			Gizmos.color = color;
			//Spheres
			Vector3 basePos = defaultPosition + offset * width;
			Vector3 topPos = basePos + (Vector3.up * height);
			Gizmos.DrawWireSphere(basePos, width);
			Gizmos.DrawWireSphere(topPos, width);

			//Finish Capsule
			Vector3 side = Vector3.right * width;
			Gizmos.DrawLine(basePos + side, topPos + side);
			Gizmos.DrawLine(basePos - side, topPos - side);
		}
#endif
	}
}