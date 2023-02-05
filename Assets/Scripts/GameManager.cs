using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject CANVAS_DRAG_DROP;
    public GameObject BONSAI_GROUP;
    [HideInInspector] public GameObject ACTIVE_BONSAI;
    [HideInInspector] public int BONSAI_INDEX = 0;

    [SerializeField] float changeSpeed = 1f;
    int targetLerpX = 0;

    [SerializeField] AudioSource bonsaiChange;


    void Update_Active_Bonsai()
    {
        ACTIVE_BONSAI = BONSAI_GROUP.transform.GetChild(BONSAI_INDEX).gameObject;
    }

    [ContextMenu("Next_Bonsai")]
    public void Next_Bonsai()
    {
        BONSAI_INDEX += 1;
        if(BONSAI_INDEX < BONSAI_GROUP.transform.childCount)
        {    
            targetLerpX = BONSAI_INDEX * 15;
            Update_Active_Bonsai();

            //Audio
            bonsaiChange.Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Update_Active_Bonsai();
    }

    // Update is called once per frame
    void Update()
    {
        BONSAI_GROUP.transform.position = Vector2.Lerp(BONSAI_GROUP.transform.position, new Vector2(targetLerpX, BONSAI_GROUP.transform.position.y), (Time.deltaTime * changeSpeed));     
    }
}
