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
    GameObject Bonsai_Bowl;

    public void Start(){
        Bonsai_Bowl = GameObject.Find(nomeCollider);
    }


    // Update is called once per frame
    void Update(){
        
    }

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.CompareTag(nomeCollider))
		{
            anim.Play("Tesoura cortando");
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.CompareTag(nomeCollider))
		{
			anim.Play("Idle");
		}
	}

	void OnTriggerStay2D(Collider2D coll) {
        Debug.Log("Collide");
        if (coll.CompareTag(nomeCollider)) {
            toolActionEvent.Invoke();
        }
    }

   
}
