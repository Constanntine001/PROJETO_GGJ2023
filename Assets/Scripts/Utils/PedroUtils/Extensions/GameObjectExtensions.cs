// maded by Pedro M Marangon
using UnityEngine;

namespace PedroUtils
{
	public static class GameObjectExtensions
	{
		public static T GetOrAddComponent<T>(this GameObject gObj) where T : Component
		{
			var comp = gObj.GetComponent<T>();
			if (comp == null) comp = gObj.AddComponent<T>();
			return comp;
		}

		public static bool IsInsideLayerMask(this GameObject go, LayerMask layerMask) => (layerMask.value & (1 << go.layer)) > 0;
		
		public static bool IsInLayer(this GameObject go, string name) => (LayerMask.NameToLayer(name) & (1 << go.layer)) > 0;
		
		public static bool IsInSameLayerAsMe(this GameObject go, GameObject obj) => (1 << go.layer & (1 << obj.layer)) > 0;
		
		public static void Activate(this GameObject go) => go.SetActive(true);
		
		public static void Deactivate(this GameObject go) => go.SetActive(false);
		
		public static void Toggle(this GameObject go) => go.SetActive(!go.activeSelf);
	}

}