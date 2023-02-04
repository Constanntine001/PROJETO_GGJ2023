// maded by Pedro M Marangon
using UnityEngine;

namespace PedroUtils
{
	public static class AnimatorExtensions
	{
		public static bool IsPlayingAnimation(this Animator anim, string id, int layerIndex = 0) => anim.GetCurrentAnimatorStateInfo(layerIndex).IsName(id);
	}
}