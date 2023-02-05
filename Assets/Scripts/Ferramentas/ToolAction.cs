using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ToolAction : MonoBehaviour
{
    //This script does the tool specific action when inside
    //correct spot
    // Start is called before the first frame update
    public string nomeCollider = "BonsaiBowl";
    public UnityEvent toolActionEvent;
    public UnityEvent stopToolActionEvent;
    [SerializeField] private Animator anim;

	void OnTriggerEnter2D(Collider2D coll)
	{
        if (!anim || !coll.CompareTag(nomeCollider)) return;
        anim?.Play("Tesoura cortando");
	}

	void OnTriggerExit2D(Collider2D coll)
	{
        if(!anim || !coll.CompareTag(nomeCollider)) return;
        anim?.Play("Idle");
	}

	void OnTriggerStay2D(Collider2D coll)
    {
        if(!coll.CompareTag(nomeCollider)) return;
        
        Debug.Log("Collide");
        toolActionEvent.Invoke();
    }

   
}
