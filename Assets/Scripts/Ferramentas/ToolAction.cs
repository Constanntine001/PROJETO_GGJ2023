using UnityEngine;
using UnityEngine.Events;

public class ToolAction : MonoBehaviour
{
    //This script does the tool specific action when inside
    //correct spot
    // Start is called before the first frame update
    public string nomeCollider = "BonsaiBowl";
    public UnityEvent toolActionEvent;
    public UnityEvent stopToolActionEvent;

	void OnTriggerEnter2D(Collider2D coll)
	{
        if (!coll.CompareTag(nomeCollider)) return;
	}

	void OnTriggerExit2D(Collider2D coll)
	{
        if (!coll.CompareTag(nomeCollider)) return;
	}

	void OnTriggerStay2D(Collider2D coll)
    {
        if(!coll.CompareTag(nomeCollider)) return;
        
        Debug.Log("Collide");
        toolActionEvent.Invoke();
    }
}
