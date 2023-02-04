// maded by Pedro M Marangon
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PedroUtils
{
	public static class Helpers
	{
		private static Camera _cam;
		public static Camera Camera
		{
			get
			{
				if (_cam == null) _cam = Camera.main;
				return _cam;
			}
		}

		public static T GetIfNull<T>(ref T component) where T : Component
		{
			if (component == null) component = Object.FindObjectOfType<T>();
			return component;
		}
		public static T GetIfNull<T>(ref T component, Component baseObject) where T : Component
		{
			if (component == null) component = baseObject.GetComponent<T>();
			return component;
		}

		public static Task WaitForSecondsTask(float seconds) => Task.Delay((int)(1000 * seconds));
	}
}