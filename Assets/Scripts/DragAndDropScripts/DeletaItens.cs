using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletaItens : MonoBehaviour
{
    GameManager gm;

    [SerializeField] AudioSource deletaItens;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    [ContextMenu("Deleta_Itens")]
    public void Deleta_Itens()
    {
        var childCount = gm.ACTIVE_BONSAI.transform.childCount;

        if(childCount > 0)
        {
            deletaItens.Play();
        }

        for(int i = 0; i < childCount; i++)
        {
            Destroy(gm.ACTIVE_BONSAI.transform.GetChild(i).gameObject);
        }
    }

    //Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null) 
            {
                if(hit.collider.gameObject.name == "DELETA_ITEMS(PA)")
                {
                    Deleta_Itens();
                }
            }
        }
    }
}