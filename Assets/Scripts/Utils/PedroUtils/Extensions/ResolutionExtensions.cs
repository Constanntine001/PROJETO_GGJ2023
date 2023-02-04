// maded by Pedro M Marangon
using UnityEngine;

namespace PedroUtils
{
	public static class ResolutionExtensions
	{
		public static bool IsEqual(this Resolution a, Resolution b) => a.width == b.width && a.height == b.height;
	}

}