// maded by Pedro M Marangon
using System.Collections.Generic;
using UnityEngine;

namespace PedroUtils
{
	public static class ComponentExtensions
	{
		public static void Suicide(this Component gObj, float time = 0) => Object.Destroy(gObj.gameObject, time);
		
		public static List<Transform> GetParents(this Component[] comps)
		{
			List<Transform> list = new List<Transform>();

			foreach (var comp in comps)
				list.Add(comp.transform.parent);

			return list;
		}
		
		public static List<Transform> GetParents(this List<Component> comps)
		{
			List<Transform> list = new List<Transform>();

			foreach (var comp in comps)
				list.Add(comp.transform.parent);

			return list;
		}
	}

}