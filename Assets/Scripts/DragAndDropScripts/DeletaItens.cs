using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletaItens : MonoBehaviour
{
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    [ContextMenu("Deleta_Itens")]
    public void Deleta_Itens()
    {
        var childCount = gm.ACTIVE_BONSAI.transform.childCount;
        for(int i = 0; i < childCount; i++)
        {
            Destroy(gm.ACTIVE_BONSAI.transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
