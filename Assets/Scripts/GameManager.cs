using Economy;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject CANVAS_DRAG_DROP;
    public GameObject BONSAI_GROUP;
    [HideInInspector] public GameObject ACTIVE_BONSAI;
    [HideInInspector] public int BONSAI_INDEX = 0;

    [SerializeField] float changeSpeed = 1f;
    int targetLerpX = 0;

    [SerializeField] AudioSource bonsaiChange;

    [SerializeField] private List<GameObject> BonsaiTypes = new List<GameObject>();

    void Update_Active_Bonsai()
    {
        ACTIVE_BONSAI = BONSAI_GROUP.transform.GetChild(BONSAI_INDEX).gameObject;
    }

    [ContextMenu("Next_Bonsai")]
    public void Next_Bonsai()
    {
        BONSAI_INDEX++;

        int randomInt = Random.Range(0, 3);

        Transform lastTransform = BONSAI_GROUP.transform.GetChild(BONSAI_GROUP.transform.childCount - 1);
        GameObject newBonsai = Instantiate(BonsaiTypes[randomInt], BONSAI_GROUP.transform);
        newBonsai.transform.localPosition = new Vector3(lastTransform.localPosition.x - 15, lastTransform.localPosition.y, lastTransform.localPosition.z);

        Debug.Log("Bonsai Group: " + BONSAI_GROUP.name);
        Debug.Log("Bonsai Group Child Count: " + BONSAI_GROUP.transform.childCount);

        if(ACTIVE_BONSAI.transform.childCount > 0) FindObjectOfType<PlayerInventory>().AddMoney(50);

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
