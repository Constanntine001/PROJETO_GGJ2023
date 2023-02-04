// maded by Pedro M Marangon
using System;
using UnityEngine;

namespace PedroUtils
{
	public static class FloatExtensions
	{
		public static float With2Decimals(this float v) => Mathf.Round(v * 100f) / 100f;
		
		public static float With3Decimals(this float v) => Mathf.Round(v * 1000f) / 1000f;
		
		public static float ClampAngle(this float angle, float min, float max)
		{
			if (angle < -360f) angle += 360f;
			if (angle > 360f) angle -= 360f;
			return Mathf.Clamp(angle, min, max);
		}
		
		public static float Clamp01WithAction(float value, Action<float> action)
		{
			var val = Mathf.Clamp01(value);
			action?.Invoke(val);
			return val;
		}
	}

}