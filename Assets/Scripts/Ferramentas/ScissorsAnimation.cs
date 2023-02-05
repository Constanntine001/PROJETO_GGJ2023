using UnityEngine;

public class ScissorsAnimation : MonoBehaviour
{
	[SerializeField] private Animator anim;

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (!anim) return;
		anim?.Play("Tesoura cortando");
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if (!anim) return;
		anim?.Play("Idle");
	}
}